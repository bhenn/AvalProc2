﻿@ModelType AvalProc.Mp

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Mp</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Nome)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Nome)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Descricao)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Descricao)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Pa.Nome)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Pa.Nome)
    </div>
</fieldset>
@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using