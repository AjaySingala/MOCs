#Demonstration: Using Azure PowerShell

# create a new storage group 
New-AzureRmResourceGroup -Name 20533D0101-DemoRG -Location "Central US"

# to verify that the new resource group was successfully created
Get-AzureRmResourceGroup
Get-AzureRmResourceGroup -Name 20533D0101-DemoRG

## Create a storage account
New-AzureRmStorageAccount -ResourceGroupName 20533D0101-DemoRG -Location "Central US" -Name 20533d0101demostorage -SkuName Standard_LRS

# verify that the new storage account was successfully created.
Get-AzureRmStorageAccount
Get-AzureRmStorageAccount -Name 20533d0101demostorage -ResourceGroupName 20533D0101-DemoRG

# delete the resource group you created earlier in this demonstration.
Remove-AzureRmResourceGroup -Name 20533D0101-DemoRG

# verify that the new storage account was successfully deleted.
Get-AzureRmResourceGroup -Name 20533D0101-DemoRG
Get-AzureRmStorageAccount
Get-AzureRmStorageAccount -Name 20533d0101demostorage -ResourceGroupName 20533D0101-DemoRG



 