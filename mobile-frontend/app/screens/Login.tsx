import { View, Text, TextInput, Pressable } from "react-native";
import React, { useState } from "react";
import { useAuth } from "../context/AuthContext";
import { handleError } from "../helpers/ErrorHandler";

import { LinearGradient } from "expo-linear-gradient";
import FontAwesome6 from "@expo/vector-icons/FontAwesome6";
import Fontisto from "@expo/vector-icons/Fontisto";
import EvilIcons from "@expo/vector-icons/EvilIcons";

const Login = () => {
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const { onLogin } = useAuth();

  const handleLogin = async () => {
    const result = await onLogin!(userName, password);
    if (result && result.error) {
      handleError(result.error);
    }
  };

  return (
    <View className="flex flex-1 items-center justify-center bg-white">
      <View className="w-5/6 mb-6">
        <Text className="text-3xl font-bold">Login</Text>
        <Text className="text-lg text-gray-400">
          Please sign in to continue.
        </Text>
      </View>
      <View className="w-5/6 mt-4 items-center">
        <View className="flex-row my-2 w-full rounded border-2 border-blue-400 gap-1 p-3 items-center">
          <Fontisto name="email" size={24} color="gray" />
          <TextInput
            className="text-lg"
            placeholder="Username"
            onChangeText={(text: string) => setUserName(text)}
            value={userName}
          />
        </View>
        <View className="flex-row my-2 w-full rounded border-2 border-blue-400 p-3 items-center">
          <EvilIcons name="lock" size={30} color="gray" />
          <TextInput
            className="text-lg"
            secureTextEntry
            placeholder="Password"
            onChangeText={(text: string) => setPassword(text)}
            value={password}
          />
        </View>
        <View className="w-full items-end">
          <LinearGradient
            className="my-2 w-1/2 items-center rounded-full p-3"
            colors={["#00C6FB", "#005BEA"]}
            start={{ x: 0.2, y: 0.2 }}
            end={{ x: 1, y: 1 }}
          >
            <Pressable onPress={() => handleLogin()}>
              <Text className="text-lg font-bold text-white">
                {"LOGIN  "}
                <FontAwesome6 name="arrow-right-long" size={20} color="white" />
              </Text>
            </Pressable>
          </LinearGradient>
        </View>
      </View>
    </View>
  );
};

export default Login;
