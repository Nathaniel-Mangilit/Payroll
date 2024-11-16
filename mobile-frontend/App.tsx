import { AuthProvider } from "./app/context/AuthContext";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import React from "react";

import { RootLayout } from "./app/hooks/RootLayout";

const Stack = createNativeStackNavigator();
export default function App() {
  return (
    <AuthProvider>
      <RootLayout />
    </AuthProvider>
  );
}
