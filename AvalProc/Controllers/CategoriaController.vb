﻿Imports System.Data.Entity

<Authorize>
Public Class CategoriaController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Categoria/

    Function Index() As ActionResult
        Return View()
    End Function

    Function List() As ActionResult
        Return PartialView(db.Categorias.ToList())
    End Function

    '
    ' GET: /Categoria/Create

    Function Create() As ActionResult
        Return PartialView()
    End Function

    '
    ' POST: /Categoria/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal categoria As Categoria) As ActionResult
        If ModelState.IsValid Then
            db.Categorias.Add(categoria)
            db.SaveChanges()
            Return RedirectToAction("List")
        End If

        Return PartialView(categoria)
    End Function

    '
    ' GET: /Categoria/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim categoria As Categoria = db.Categorias.Find(id)
        If IsNothing(categoria) Then
            Return HttpNotFound()
        End If
        Return PartialView(categoria)
    End Function

    '
    ' POST: /Categoria/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal categoria As Categoria) As ActionResult
        If ModelState.IsValid Then
            db.Entry(categoria).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("List")
        End If

        Return PartialView(categoria)
    End Function

    '
    ' POST: /Categoria/Delete/5
    <HttpPost()> _
    Function Delete(ByVal id As Integer) As RedirectToRouteResult
        Dim categoria As Categoria = db.Categorias.Find(id)
        db.Categorias.Remove(categoria)
        db.SaveChanges()
        Return RedirectToAction("List")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class