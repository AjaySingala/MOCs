﻿# Module 7: Structuring ASP.NET MVC 5 Web Applications

# Lesson 2: Configuring Routes

### Demonstration: How to Add Routes

#### Preparation Steps

1. Ensure that you have cloned the 20486C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486-DevelopingASPNETMVCWebApplications/tree/master/Allfiles
2. Open **File Explorer**.
3. Go to **Allfiles\20486c\Mod07\Democode\OperasWebsites_07_begin**.
4. Double-click **OperasWebsites.sln**.

#### Demonstration Steps

1. On the **DEBUG** menu of the **OperasWebsites - Microsoft Visual Studio** window, click **Start Debugging**.
2. On the **Operas I Have Seen** page, click **operas I&#39;ve seen**.
3. On the **Index** page, click **Details** corresponding to **Cosi Fan Tutte**.
4. In the Address bar of the **Microsoft Edge** window, note that the URL is **http://localhost:[port]/**.

   >**Note:** This URL indicates that the controller is **Opera**, the action is **Details**, and the ID is **1**.

5. In the **Microsoft Edge** window, click **Close**.
6. On the **DEBUG** menu of the **OperasWebsites - Microsoft Visual Studio** window, click **Stop Debugging**.
7. In the **Solution Explorer** pane, expand **OperasWebsites**, expand **Controllers**, and then click **OperaController.cs**.
8. In the **OperaController.cs** code window, place the mouse cursor at the end of the **Details** action code block, press Enter twice, and then type the following code.

  ```cs
       public ActionResult DetailsByTitle(string title)
       {
       }
```
9. In the **DetailsByTitle** action code block, type the following code, and then press Enter.

  ```cs
       Opera opera = (Opera)(from o in contextDB.Operas where o.Title == title select o).FirstOrDefault();      
```
10. In the **DetailsByTitle** action code block, after the code that you just typed, type the following code.

  ```cs
       if (opera == null)
       {
          return HttpNotFound();
       }
       return View("Details", opera);
```
11. In the **Solution Explorer** pane, under OperasWebsites, expand **App_Start**, and then click **RouteConfig.cs**.
12. In the **RouteConfig.cs** code window, locate the following code.

  ```cs
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
```
13. Place the mouse cursor at the end of the call to the **IgnoreRoute()** method, press Enter twice, and then type the following code.

  ```cs
       routes.MapRoute(name: "OperaTitleRoute",url: "opera/title/{title}",defaults: new { controller = "Opera", action ="DetailsByTitle" });     
```
14. On the **FILE** menu of the **OperasWebsites - Microsoft Visual Studio** window, click **Save All**.
15. On the **DEBUG** menu of **OperasWebsites - Microsoft Visual Studio** window, click **Start Debugging**.
16. On the Operas I Have Seen page, click **operas I&#39;ve seen**.
17. In the Address bar of the **Microsoft Edge** window, change the existing URL to **http://localhost:[port]/opera/title/Cosi Fan Tutte**, and then click **Go**.

   >**Note:** The details of the **Cosi Fan Tutte** opera are displayed.

18. In the **Microsoft Edge** window, click **Close**.
19. In the **OperasWebsites - Microsoft Visual Studio** window, click **Close**.
20. In the **Microsoft Visual Studio** dialog box, click **Yes**.

# Lesson 3: Creating a Navigation Structure

### Demonstration: How to Build Site Navigation

#### Preparation Steps

1. Ensure that you have cloned the 20486C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20486-DevelopingASPNETMVCWebApplications/tree/master/Allfiles 
2. Open **File Explorer**.
3. Go to **Allfiles\20486c\Mod07\Democode\OperasWebsites_07_begin**.
4. Double-click **OperasWebsites.sln**.

#### Demonstration Steps

1. On the **Tools** menu of the **OperasWebsites - Microsoft Visual Studio** window, point to **NuGet Package Manager** and then click **Package Manager Console**.
2. In **Package Manager Console** window, type the following command and then press Enter.

  ```cs
       Install-Package MvcSiteMapProvider.MVC5 -Version 4.6.22
```
3. In the **Solution Explorer** pane of the **OperasWebsites - Microsoft Visual Studio** window, expand **OperasWebsites**, collapse **App_Start**, and then collapse **Controllers**.
4. In the **Solution Explorer** pane, under **Global.asax**, click **Mvc.sitemap**.
5. In the **Mvc.sitemap** code window, locate the following code.

  ```cs
       <mvcSiteMapNode title="Home" controller="Home" action="Index">
```
6. Place the mouse cursor at the end of the located code, press Enter, and then type the following code.

  ```cs
       <mvcSiteMapNode title="All Operas" controller="Opera" action="Index" key="AllOperas" />
```
7. On the **BUILD** menu of the **OperasWebsites - Microsoft Visual Studio** window, click **Build Solution**.
8. In the **Solution Explorer** pane, expand **Views**, expand **Home**, and then click **Index.cshtml**.
9. In the **Index.cshtml** code window, place the mouse cursor after the **&lt;div&gt;** tag, press Enter, and then type the following code.

  ```cs
       Menu: @Html.MvcSiteMap().Menu(false, false, true)
```
10. Place the mouse cursor at the end of the site map menu code block, press Enter, and then type the following code.

  ```cs
        Breadcrumb Trail: @Html.MvcSiteMap().SiteMapPath()
```
11. In the **Solution Explorer** pane, under **Views**, expand **Opera**, and then click **Index.cshtml**.
12. In the **Index.cshtml** code window, place the mouse cursor at the end of the **&lt;body&gt;** tag, press Enter, and then type the following code.

  ```cs
        Menu: @Html.MvcSiteMap().Menu(false, false, true)
```
13. Place the mouse cursor at the end of the site map menu code block, press Enter, and then type the following code.

  ```cs
        Breadcrumb Trail: @Html.MvcSiteMap().SiteMapPath()
```
14. On the **DEBUG** menu of the **OperasWebsites - Microsoft Visual Studio** window, click **Start Debugging**.

    >**Note:** On the **Operas I Have Seen** page, ensure that a menu is added.

15. On the **Index** page, note that the **Main Opera List** is displayed.

    >**Note:** On the **Index** page, you can also view the menu.

16. In the **Breadcrumb Trail** section of the Index page, click **Home**.

    >**Note:** The **Operas I Have Seen** page is displayed.

17. On the **Operas I Have Seen** page, under **Menu**, click **About**.

    >**Note:** The **About** page of the web application is displayed.

18. In the **Microsoft Edge** window, click **Close**.
19. In the **OperasWebsites - Microsoft Visual Studio** window, click **Close**.
20. In the **Microsoft Visual Studio** dialog box, click **Yes**.

©2016 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
