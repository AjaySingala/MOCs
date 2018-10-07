New-AzureRmResourceGroup -Name TestRG -Location uswest `
-TemplateFile '.\azuredeploy.json' `
-TemplateParameterFile '.\azuredeploy.parameters.json'
