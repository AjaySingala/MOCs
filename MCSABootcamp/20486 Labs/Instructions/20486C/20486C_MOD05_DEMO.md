# Module 5: Developing ASP.NET MVC 5 Views

# Lesson 2: Using HTML Helpers

### Demonstration: How to Use HTML Helpers

#### Preparation Steps

1. Ensure that you have cloned the 20486C directory from GitHub. It contains the code segments for this course's labs and demos. 
https://github.com/MicrosoftLearning/20486-DevelopingASPNETMVCWebApplications/tree/master/Allfiles
2. Start **File Explorer**.
3. Navigate to **Allfiles/20486C/Mod05/DemoCode/OperasWebsites_05_begin**.
4. Open the **OperasWebSites.sln** project.

#### Demonstration Steps

1. In Solution Explorer **"OperasWebsites - Microsoft Visual Studio"**, Right-click Solution 'OperasWebsites' (1 Project) and then click **Build Solution**.
2. In the Solution Explorer pane of the **"OperasWebsites - Microsoft Visual Studio"** window, expand **Controllers**, and then click  **OperaController.cs**.
3. In the **OperaController.cs** code window, locate the following code, right-click the code, and then click **Add View**.

  ```cs
		public ActionResult Create()
```
4. In the **View Name** box of the **Add View** dialog box, ensure that the name displayed is **Create**.
5. In the **Template** box, ensure that the name displayed is **Empty**.
6. In the **Model class** box, ensure that the value is **Opera (OperasWebsites.Models)**. If not, in the **Model class** box, click **Opera (OperasWebsites.Models)**.
7. In the **Add View** dialog box, ensure that the **Use a layout page** check box is not selected, and then click **Add**.
8. In the **DIV** element of the **Create.cshtml** code window, type the following code.

		<h2>Add an Opera</h2>

9. Place the mouse cursor at the end of the **&lt;/h2&gt;** tag, press Enter twice, and then type the following code.

  ```cs
	@using (Html.BeginForm("Create","Opera",FormMethod.Post))   
    {
    }
```
10. In the **using** code block, type the following code.

  ```cs
		<p> 
		    @Html.LabelFor(model =>model.Title):        
		    @Html.EditorFor(model =>model.Title) 
		    @Html.ValidationMessageFor(model =>model.Title)   
		</p>
```
11. Place the mouse cursor at the end of the **&lt;/p&gt;** tag corresponding to the **model.Title** property, press Enter twice, and then type the following code.

  ```cs
		<p>
		    @Html.LabelFor(model =>model.Year): 
		    @Html.EditorFor(model =>model.Year)
		    @Html.ValidationMessageFor(model => model.Year)		   
		</p>
```
12. Place the mouse cursor at the end of the **&lt;/p&gt;** tag corresponding to the **model.Year** property, press Enter twice, and then type the following code.

  ```cs
		<p>
		    @Html.LabelFor(model =>model.Composer):
		    @Html.EditorFor(model =>model.Composer) 
		    @Html.ValidationMessageFor(model => model.Composer)
		</p>
```
13. Place the mouse cursor at the end of the **&lt;/p&gt;** tag corresponding to the **model.Composer** property, press Enter twice, and then type the following code.

  ```cs
		<input type="submit" value="Create"/>
```
14. Place the mouse cursor at the end of the **&lt;input&gt;** tag, press Enter, and then type the following code.

  ```cs
		@Html.ActionLink("Back to List", "Index")
```
15. On the **DEBUG** menu of the **"OperasWebsites - Microsoft Visual Studio"** window, click **Start Debugging**.

    >**Note** : The Operas I Have Seen page is displayed.

16. On the Operas I Have Seen page, click **operas I've seen**.

    >**Note** : On the Index page, the list of Operas is displayed.

17. On the Index page, click **Create New**.

    >**Note** : The Add an Opera page is displayed.

18. In the **Year** box of the Add an Opera page, type **1597**, and then click **Create**.

    >**Note** : Messages corresponding to the **Title**, **Year**, and **Composer** boxes are displayed. The web application mandates you to enter values in all the boxes. Alerts are also displayed for any inappropriate entries, with relevant messages.

19. In the **Title** box of the Add an Opera page, type **Rigoletto**.
20. In the **Year** box of the Add an Opera page, type **1851**.
21. In the **Composer** box of the Add an Opera page, type **Verdi**, and then click **Create**.

    >**Note** : The Opera is created with the mentioned values.

22. In the Windows Microsoft Edge window, click **Close**.
23. In the **"OperasWebsites - Microsoft Visual Studio"** window, click **Stop Debugging**.
24. In the **"OperasWebsites - Microsoft Visual Studio"** window, click **Close**.

©2016 Microsoft Corporation. All rights reserved. 

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
