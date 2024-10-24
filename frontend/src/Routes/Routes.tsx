import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/Admin/Home/HomePage";
import DashboardPage from "../Pages/Admin/Dashboard/DashboardPage";
import ProtectedRoute from "./ProtectedRoute";
import EmployeePage from "@/Pages/Admin/Employees/EmployeePage";
import LoginPage from "@/Pages/Auth/Login/LoginPage";
import UserHomePage from "@/Pages/User/UserHome/UserHomePage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      {
        path: "dashboard",
        element: (
          <ProtectedRoute>
            <DashboardPage />
          </ProtectedRoute>
        ),
      },
      {
        path: "employees",
        element: (
          <ProtectedRoute>
            <EmployeePage />
          </ProtectedRoute>
        ),
      },
      {
        path: "userpage",
        element: (
          <ProtectedRoute>
            <UserHomePage />
          </ProtectedRoute>
        ),
      },
      { path: "login", element: <LoginPage /> },
    ],
  },
]);
