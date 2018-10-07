# Module 12: Building a Resilient ASP.NET MVC 5 Web Application

# Lesson 2: State Management

### Demonstration: How to Store and Retrieve State Information

#### Preparation Steps

1.	Ensure that you have cloned the 20486C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486-DevelopingASPNETMVCWebApplications/tree/master/Allfiles
2.  Open **File Explorer**.
3.	Go to **Allfiles\20486c\Mod12\Democode\OperasWebsites_12_begin**.
4.	Double-click **OperasWebsites.sln**.

#### Demonstration Steps

1. In the **Solution Explorer** pane of the **OperasWebsites – Microsoft Visual Studio** window, under **OperasWebsites**, expand **Controllers**, and then click **HomeController.cs**.
2. In the **HomeController.cs** code window, locate the following code.

  ```cs
       public ActionResult About()
       {
          return View("");
       }
```
3. Place the mouse cursor at the end of the located code, press Enter twice, and then type the following code.

  ```cs
       public ContentResult GetBackground()
       {
       }
```
4. Place the mouse cursor within the **GetBackground** action code block, and then type the following code.

  ```cs
       string style;
       if (Session["BackgroundColor"] != null)
       {
       }
       else
       {
       }
```
5. Place the mouse cursor within the **if** statement code block you just added, and then type the following code.

  ```cs
       style = String.Format("background-color: {0};", Session["BackgroundColor"]);
```
6. Place the mouse cursor within the **else** statement code block you just added, and then type the following code.

  ```cs
       style = "background-color: #dc9797;";
```
7. Place the mouse cursor at the end of the **GetBackground** action code block and outside the **if…else** statements, press Enter, and then type the following code.

  ```cs
       return Content(style);
```
8. Place the mouse cursor outside any action code block but inside the **HomeController** class, and then type the following code.

  ```cs
       public ActionResult SetBackground(string color)
       {
       }
```
9. Place the cursor within the **SetBackground** action code block, and then type the following code.

  ```cs
       Session["BackgroundColor"] = color;
       return View("Index");
```
10. In the **Solution Explorer** pane, expand **Views**, expand **Home**, and then click **Index.cshtml**.
11. In the **Index.cshtml** code window, place the mouse cursor at the end of the **&lt;/P>** element, press Enter twice, and then type the following code.

  ```cs
        <p>
           Choose a background color:
        </p>
```
12. Place the mouse cursor at the end of the text in the **&lt;/P>** element, press Enter, and then type the following code.

  ```cs
        @Html.ActionLink("Pink", "SetBackground", new { color = "#dc9797"})
```
13. Place the mouse cursor at the end of the link you just created, press Enter, and then type the following code.

  ```cs
        @Html.ActionLink("Blue", "SetBackground", new { color = "#82bbf2"})
```
14. In the **Solution Explorer** pane, expand **Shared**, and then click **_SiteTemplate.cshtml**.
15. In the **_SiteTemplate.cshtml** code window, locate the following code.

  ```cs
        <body>
```
16. Replace the located code with the following code.

  ```cs
        <body style="@Html.Action("GetBackground", "Home")">
```
17. On the **DEBUG** menu of the **OperasWebsites – Microsoft Visual Studio** window, click **Start Debugging**.
18. On the **Operas I Have Seen** page, click **Blue**, and then note that the blue background color has been applied to the home page.
19. On the **Operas I Have Seen** page, click **All Operas**.

    >**Note:** If the background color of the page is blue, click **Refresh**.

20. On the **Index of Operas** page, click **Details** corresponding to the title, **Cosi Fan Tutte**.
21. On the **Cosi Fan Tutte** page, note that the blue background color has been applied to the page.

    >**Note:** The blue background preference is applied to all pages of the application.

22. On the **Opera: Cosi Fan Tutte** page, click **Home**.
23. On the **Operas I Have Seen** page, click **Pink**, and then note that the pink background color has been applied to the home page.

    >**Note:** If the background color of the page is blue, click **Refresh**.

24. On the **Operas I Have Seen** page, click **All Operas**.
25. On the **Index of Operas** page, click **Details** corresponding to the title, **Cosi Fan Tutte**.
26. On the **Cosi Fan Tutte** page, note that the pink background color has been applied to the page.
27. In the **Microsoft Edge** window, click **Close**.
28. In the **OperasWebsites – Microsoft Visual Studio** window, click **Close**.
29. If the message **Do you want to stop debugging?** is displayed, click **Yes**.

©2016 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here. 
