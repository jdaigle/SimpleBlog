<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<html>
    <head>
        <title>SimpleBlog Log On</title>
    </head>
    <body>
        <h2>Log On</h2>
        <p>
            <%= Html.ActionLink("Go Back", MVC.Articles.Index()) %>
        </p>
        <p>
            Please enter the <b>admin</b> password.
        </p>
        <%= Html.ValidationSummary("Login was unsuccessful. Please correct the errors and try again.") %>

        <% using (Html.BeginForm()) { %>
            <div>
                <fieldset>
                    <legend>Authentication</legend>
                    <p>
                        <label for="password">Password:</label>
                        <%= Html.Password("password") %>
                        <%= Html.ValidationMessage("password") %>
                    </p>
                    <p>
                        <%= Html.CheckBox("rememberMe") %> <label class="inline" for="rememberMe">Remember me?</label>
                    </p>
                    <p>
                        <input type="submit" value="Log On" />
                    </p>
                </fieldset>
            </div>
        <% } %>
    </body>
</html>