import {
  View,
  Text,
  Touchable,
  TouchableOpacity,
  Pressable,
} from "react-native";
import React, { ReactNode, useEffect, useState } from "react";
import { API_URL, useAuth } from "../context/AuthContext";
import axios from "axios";
import { StatusBar } from "expo-status-bar";
import Entypo from "@expo/vector-icons/Entypo";
import AntDesign from "@expo/vector-icons/AntDesign";
import Ionicons from "@expo/vector-icons/Ionicons";
import FontAwesome5 from "@expo/vector-icons/FontAwesome5";
import { LinearGradient } from "expo-linear-gradient";
import MaterialCommunityIcons from "@expo/vector-icons/MaterialCommunityIcons";
import { useNavigation } from "@react-navigation/native";
import { SafeAreaView } from "react-native-safe-area-context";
import useFetch from "../context/useFetch";
import { handleError } from "../helpers/ErrorHandler";
interface Props {
  timeLog: string;
  logStatus: string;
}

function Home(props: Props) {
  const { data }: any = useFetch();
  const navigation = useNavigation();
  const [clockedIn, setClockedin] = useState(false);

  const clockInHandler = async () => {
    const timeLog = new Date();
    const logStatus = "Clocked In";
    console.log(timeLog);
    try {
      const result = await axios.post(
        `${API_URL}/attendance/${data[0].id}`,
        {
          timeLog,
          logStatus,
        },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      alert("Welcome! \n- You have Clocked In!");
      setClockedin(true);
    } catch (error) {
      handleError(error);
    }
  };
  const clockOutHandler = async () => {
    const timeLog = new Date();
    const logStatus = "Clocked Out";
    console.log(timeLog);
    try {
      const result = await axios.post(
        `${API_URL}/attendance/${data[0].id}`,
        {
          timeLog,
          logStatus,
        },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      alert("Thank you! \n- You have Clocked Out!");
      setClockedin(false);
    } catch (error) {
      handleError(error);
    }
  };

  return (
    <SafeAreaView className="grid h-full bg-white items-center">
      <StatusBar style="auto" />
      <View className="w-full flex-row mb-6 justify-start p-2 items-center">
        <View className="w-1/6 ml-4 -mr-6 items-start justify-center">
          {/* @ts-ignore */}
          <Pressable onPress={() => navigation.navigate("Profile")}>
            <Entypo name="dots-three-horizontal" size={30} color="black" />
          </Pressable>
        </View>
        <View className="flex w-1/6 items-center">
          <Ionicons name="person-circle" size={40} color="black" />
        </View>
        <View className="flex w-3/6 items-center">
          <Text className="text-xl font-bold">
            {data &&
              // @ts-ignore
              `${data[0].firstName} ${data[0].lastName[0].toUpperCase()}.`}
          </Text>

          <Text>{"8:00 AM - 5:00 PM"}</Text>
        </View>
        <View className="w-1/6 items-end justify-center">
          <AntDesign name="notification" size={24} color="black" />
        </View>
      </View>
      <View className="w-5/6 items-center justify-center">
        <LinearGradient
          className="my-2 w-full rounded p-4 h-24 max-h-24"
          colors={["#00C6FB", "#005BEA"]}
          start={{ x: 0.2, y: 0.2 }}
          end={{ x: 1, y: 1 }}
        >
          <Text className="font-bold text-white">{"No new Notifications"}</Text>
        </LinearGradient>
      </View>

      <View className="w-5/6 justify-center mt-4">
        <Text className="text-lg font-bold">{"HR & Attendance"}</Text>
        <View className="w-full flex-row justify-between mt-4">
          <TouchableOpacity className="items-center justify-between">
            <FontAwesome5 name="money-bill-wave" size={24} color="black" />
            <Text>{"Payroll"}</Text>
          </TouchableOpacity>
          <TouchableOpacity className="items-center justify-between">
            <AntDesign name="clockcircleo" size={24} color="black" />
            <Text>{"CIAO"}</Text>
          </TouchableOpacity>
          <TouchableOpacity className="items-center justify-between">
            <Ionicons name="calendar-number-outline" size={24} color="black" />
            <Text>{"Attendance"}</Text>
          </TouchableOpacity>
          <TouchableOpacity className="items-center justify-between">
            <MaterialCommunityIcons
              name="check-outline"
              size={24}
              color="black"
            />
            <Text>{"My Request"}</Text>
          </TouchableOpacity>
        </View>
      </View>

      <View className="absolute bottom-3 w-5/6 items-center ">
        <TouchableOpacity
          disabled={clockedIn}
          onPress={() => {
            clockInHandler();
          }}
          className="w-full bg-white shadow-lg items-center justify-between"
        >
          <LinearGradient
            className=" my-2 w-full rounded-full p-3 max-h-24 items-center justify-center"
            colors={["#00C6FB", "#005BEA"]}
            start={{ x: 0.2, y: 0.2 }}
            end={{ x: 1, y: 1 }}
          >
            <Text className="font-bold text-white">{"Clock In"}</Text>
          </LinearGradient>
        </TouchableOpacity>
        <TouchableOpacity
          disabled={!clockedIn}
          onPress={() => clockOutHandler()}
          className="w-full shadow-lg items-center justify-between p-3 rounded-full border-2"
        >
          <Text className="font-bold">{"Clock out"}</Text>
        </TouchableOpacity>
      </View>
    </SafeAreaView>
  );
}

export default Home;
