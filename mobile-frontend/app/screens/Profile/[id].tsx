import { View, Text, Pressable, TouchableOpacity } from "react-native";
import React, { useState } from "react";
import { SafeAreaView } from "react-native-safe-area-context";

// icons import
import Entypo from "@expo/vector-icons/Entypo";
import AntDesign from "@expo/vector-icons/AntDesign";
import Ionicons from "@expo/vector-icons/Ionicons";
import Octicons from "@expo/vector-icons/Octicons";
import FontAwesome6 from "@expo/vector-icons/FontAwesome6";

import { useNavigation } from "@react-navigation/native";
import { useAuth } from "../../context/AuthContext";
import useFetch from "../../context/useFetch";

const Profile = () => {
  const { data } = useFetch();
  const navigation = useNavigation();
  const { onLogout } = useAuth();

  return (
    <SafeAreaView className="grid h-full bg-white items-center">
      <View className="w-full flex-row justify-start p-4 items-center">
        <View className="w-1/3 items-start justify-center">
          {/* @ts-ignore */}
          <Pressable onPress={() => navigation.navigate("Home")}>
            <Entypo name="chevron-left" size={30} color="black" />
          </Pressable>
        </View>

        <View className="flex w-1/3 items-center">
          <Text className="text-xl font-bold">My Profile</Text>
        </View>
        <View className="flex w-1/3  items-end justify-center">
          <AntDesign name="notification" size={24} color="black" />
        </View>
      </View>

      <View className="w-full  justify-start p-2 items-center">
        <View className="flex w-full items-center">
          <Ionicons name="person-circle" size={100} color="black" />

          <Text className="text-xl font-bold">
            {/* ts-ignore */}
            {data &&
              `${data[0].firstName} ${data[0].middleName[0]}. ${data[0].lastName}`}
          </Text>
          <Text className="text-l font-bold">
            {data && data[0].workInfos[0].position}
          </Text>
          <Text className="text-base text-gray-500">
            {data && data[0].workInfos[0].workPlace}
          </Text>

          <Text className="text-xl font-bold mt-4">ID :EMD2400{data?.id}</Text>
        </View>

        <View className="w-5/6 pt-4 justify-center">
          <Text className="text-xl font-bold">My Account</Text>
          <View className="w-full drop-shadow-2xl rounded-lg bg-gray-100 mt-2 p-4">
            <TouchableOpacity className="flex flex-row gap-4">
              <Octicons name="person" size={24} color="black" />
              <Text className="text-base font-bold">Basic Information</Text>
            </TouchableOpacity>
            <TouchableOpacity className="flex flex-row gap-3">
              <FontAwesome6 name="building-columns" size={24} color="black" />
              <Text className="text-base font-bold">
                Government Information
              </Text>
            </TouchableOpacity>
          </View>
          <Text className="text-xl font-bold">My Work</Text>
          <View className="w-full drop-shadow-2xl rounded-lg bg-gray-100 mt-2 p-4">
            <TouchableOpacity className="flex">
              <Text className="text-base font-bold">Work Information</Text>
            </TouchableOpacity>
            <TouchableOpacity className="flex mt-2">
              <Text className="text-base font-bold">Work Schedule</Text>
            </TouchableOpacity>
          </View>
        </View>
      </View>

      <TouchableOpacity
        onPress={onLogout}
        className="absolute bottom-5  w-1/2 drop-shadow-2xl items-center rounded-full bg-red-500 p-3"
      >
        <Text className="text-base font-bold">Logout</Text>
      </TouchableOpacity>
    </SafeAreaView>
  );
};

export default Profile;
