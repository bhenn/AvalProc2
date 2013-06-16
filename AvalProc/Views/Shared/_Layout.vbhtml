<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>@ViewData("Title")</title>
    @Styles.Render("~/Content/css")
    @Styles.Render("~/Content/bootstrap")

    @Styles.Render("~/Content/themes/base/css")

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryui")

    @Scripts.Render("~/bundles/modernizr")
    @Scripts.Render("~/bundles/bootstrap")

    @Scripts.Render("~/bundles/jqueryval")

</head>
<body>
    <div id="mainNav" class="navbar navbar-inverse navbar-fixed-top">
        @RenderPage("~/Views/Shared/_Topo.vbhtml")
    </div>
    <div class="container">
        <div class="row">
                    @RenderPage("~/Views/Shared/_MenuDireita.vbhtml")        
            <div class="span9">
                @RenderBody()
            </div>
        </div>

        @RenderSection("scripts", required:=False)
        
    </div>
</body>
</html>
