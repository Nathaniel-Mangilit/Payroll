import { NavigationContainer } from "@react-navigation/native";
import { useAuth } from "../context/AuthContext";
import { createNativeStackNavigator } from "@react-navigation/native-stack";

import { Pressable, Text } from "react-native";
import Login from "../screens/Login";
import Home from "../screens/Home";
import Profile from "../screens/Profile/[id]";

export type RootLayoutProps = {
  Login: any;
  Home: any;
  Profile: any;
};

const Stack = createNativeStackNavigator<RootLayoutProps>();

export const RootLayout = () => {
  const { authState } = useAuth();
  return (
    <NavigationContainer>
      <Stack.Navigator>
        {authState?.authenticated ? (
          <>
            <Stack.Screen
              name="Home"
              // @ts-ignore
              component={Home}
              options={{
                headerShown: false,
              }}
            />
            <Stack.Screen
              name="Profile"
              component={Profile}
              options={{ headerShown: false }}
            />
          </>
        ) : (
          <Stack.Screen
            name="Login"
            component={Login}
            options={{ headerShown: false }}
          />
        )}
      </Stack.Navigator>
    </NavigationContainer>
  );
};
