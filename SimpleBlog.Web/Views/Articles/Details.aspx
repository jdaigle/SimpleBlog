<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<SimpleBlog.Web.Models.Article>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Details - <%= Model.Title %></title>
</head>
<body>
    <h1><%= Model.Title %></h1>
    <h2><%= Model.ShowOn.ToShortDateString() %></h2>
    <p>
        <%= Model.Content %>
    </p>
    <p>
        <%= Html.ActionLink("Back to List", MVC.Articles.List()) %>
    </p>
</body>
</html>

