Add-AzureRmAccount

Select-20533DSubscriptionARM

$resourceGroupName = '20533D0401-LabRG'
$saPrefix = 'sa20533d04'
$saType = 'Standard_LRS'

$resourceGroup = Get-AzureRmResourceGroup -Name $resourceGroupName

# IMP: determine the storage account name if there are multiple accounts or else it won't work!
# $storageAccount = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName
$storageAccount = Get-AzureRmStorageAccount -ResourceGroupName $resourceGroupName -Name 20533d0401wdpimc7dl5y3m

If (!($storageAccount)) {
    Write-Host
    Write-Host '$storageAccount : ' $storageAccount
}
else {
    Write-Host "in here...."
}

If (!($storageAccount)) {
    $uniqueNumber = Get-Random
    $saName = $saPrefix + $uniqueNumber 
    If ((Get-AzureRmStorageAccountNameAvailability -Name $saName).NameAvailable -ne $True) { 
        Do { 
            $uniqueNumber = Get-Random
            $saName = $saPrefix + $uniqueNumber
        } Until ((Get-AzureRmStorageAccountNameAvailability -Name $saName).NameAvailable -eq $True)
    } 
    
    Write-Host '$resourceGroupName : ' $resourceGroupName 
    Write-Host '$uniqueNumber : ' $uniqueNumber
    Write-Host '$saName : ' $saName
    Write-Host '$saPrefix :' $saPrefix

    $storageAccount = New-AzureRmStorageAccount -ResourceGroupName $resourceGroupname -Name $saName -Type $saType -Location $resourceGroup.Location
}

$storageAccountKey = (Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageAccount[0].StorageAccountName)[0].Value

# we are using default container 
$containerName = 'windows-powershell-dsc'

$configurationName = 'IISInstall'
$configurationPath = "$PSScriptRoot\$configurationName.ps1"

Write-Host
Write-Host '$storageAccount : ' $storageAccount
Write-Host "$storageAccount.StorageAccountName : "  $storageAccount.StorageAccountName 
Write-Host 
Write-Host '$storageAccount.Location : ' $storageAccount.Location
Write-Host "'$storageAccount.Location :"  $storageAccount.Location
Write-Host 

$moduleURL = Publish-AzureRmVMDscConfiguration -ConfigurationPath $configurationPath -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccount.StorageAccountName -Force

$storageContext = New-AzureStorageContext -StorageAccountName $storageAccount.StorageAccountName -StorageAccountKey $storageAccountKey
$sasToken = New-AzureStorageContainerSASToken -Name $containerName -Context $storageContext -Permission r

$settingsHashTable = @{
"ModulesUrl" = "$moduleURL";
"ConfigurationFunction" = "$configurationName.ps1\$configurationName";
"SasToken" = "$sasToken"
}

$vmName1= '20533D0401-vm0'
$vmName2= '20533D0401-vm1'
$extensionName = 'DSC'
$extensionType = 'DSC'
$publisher = 'Microsoft.Powershell'
$typeHandlerVersion = '2.26'

Write-Host 'Installing IIS on ' $vmName1

Set-AzureRmVMExtension  -ResourceGroupName $resourceGroupName -VMName $vmName1 -Location $storageAccount.Location `
-Name $extensionName -Publisher $publisher -ExtensionType $extensionType -TypeHandlerVersion $typeHandlerVersion `
-Settings $settingsHashTable

## Takes a lot of time, hence install IIS only for 1 VM (vm0). Skip the second one (vm1).
#Write-Host 'Installing IIS on ' $vmName2
#
#Set-AzureRmVMExtension  -ResourceGroupName $resourceGroupName -VMName $vmName2 -Location $storageAccount.location `
#-Name $extensionName -Publisher $publisher -ExtensionType $extensionType -TypeHandlerVersion $typeHandlerVersion `
#-Settings $settingsHashTable
#
Write-Host 'Done. check the VMs.'

