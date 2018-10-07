﻿<#
.SYNOPSIS
    Deploys a template to Azure
 
.DESCRIPTION
    Deploys an Azure Resource Manager template
 
.PARAMETER subscriptionId
    The subscription id where the template will be deployed.
#>


param(
[Parameter(Mandatory=$True)]
[string]
$subscriptionId
)
 
<#
.SYNOPSIS
    Registers RPs
#>
Function RegisterRP {
    Param(
        [string]$ResourceProviderNamespace
    )
 
    Write-Host "Registering resource provider '$ResourceProviderNamespace'";
   Register-AzureRmResourceProvider -ProviderNamespace $ResourceProviderNamespace;
}
 
#******************************************************************************
# Script body
# Execution begins here
#******************************************************************************
$ErrorActionPreference = "Stop"
$resourceGroupName = "BlueYonder.Lab.07"
 
# sign in
Write-Host "Logging in...";
Login-AzureRmAccount;
 
# select subscription
Write-Host "Selecting subscription '$subscriptionId'";
Select-AzureRmSubscription -SubscriptionID $subscriptionId;
 
# Register RPs
$resourceProviders = @("microsoft.sql");
if($resourceProviders.length) {
    Write-Host "Registering resource providers"
    foreach($resourceProvider in $resourceProviders) {
        RegisterRP($resourceProvider);
    }
}
 
#Create or check for existing resource group
$resourceGroup = Get-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue
if(!$resourceGroup)
{
    $resourceGroupLocation = "eastus";
    Write-Host "Creating resource group '$resourceGroupName' in location '$resourceGroupLocation'";
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation
}
else{
    Write-Host "Using existing resource group '$resourceGroupName'";
}
 
# Get user's initials
Write-Host "Please enter your name's initials: (e.g. - John Doe = jd)";
$initials = Read-Host "Initials";
$serverName = "blueyonder07-$initials";
$databaseName = "BlueYonder.Companion.Lab07";
$hubNamespaceName = "blueyonder07-$initials";
$serviceBusRelayNamespace = "blueyonder-relay-$initials";
$hubName = "blueyonder07Hub";
$password = 'Pa$$w0rd';
 
# Start the deployment
Write-Host "Starting deployment of Azure SQL...";
New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupName -TemplateFile "./azureSql.json" -serverName $serverName -databaseName $databaseName;
Write-Host "Starting deployment of Azure Notification Hub...";
New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupName -TemplateFile "./notificationHub.json" -namespaceName $hubNamespaceName -notificationHubName $hubName;
$hubKeys = Get-AzureRmNotificationHubListKeys -AuthorizationRule  "DefaultFullSharedAccessSignature" -Namespace $hubNamespaceName -NotificationHub $hubName -ResourceGroup $resourceGroupName

Write-Host $hubKeys;
$dbConnectionString = "Server=tcp:$serverName.database.windows.net,1433;Initial Catalog=$databaseName;Persist Security Info=False;User ID=BlueYonderAdmin;Password=$password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=180;"


Write-Host "Generating BlueYonder.Companion web.config...";
Write-Host "Existing web.config backed up at web.config.backup";
Get-Content -Path "../begin/BlueYonder.Server/BlueYonder.Companion.Host/web.config" | Set-Content -Path "../begin/BlueYonder.Server/BlueYonder.Companion.Host/web.config.backup"
$companionConfig = Get-Content "CompanionWeb.config";
$companionConfig = $companionConfig.replace("{azureDBConnection}", $dbConnectionString);
$companionConfig = $companionConfig.replace("{relayNamespace}", $serviceBusRelayNamespace);
Set-Content -Path "../begin/BlueYonder.Server/BlueYonder.Companion.Host/web.config" -Value $companionConfig
Write-Host "Generating BlueYonder.Server web.config...";
Write-Host "Existing web.config backed up at web.config.backup";
Get-Content -Path "../begin/BlueYonder.Server/BlueYonder.Server.Booking.WebHost/web.config" | Set-Content -Path "../begin/BlueYonder.Server/BlueYonder.Server.Booking.WebHost/web.config.backup"
 
Write-Host "Connection string for database '$databaseName :";
Write-Host $dbConnectionString
Write-Host "Connection string for notificiation hub '$hubName' :";
Write-Host $hubKeys.PrimaryConnectionString;

