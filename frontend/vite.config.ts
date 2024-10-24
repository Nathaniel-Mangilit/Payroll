import path from "path";
import react from "@vitejs/plugin-react";
import { defineConfig } from "vite";

export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      "/query": {
        secure: false,
        target: "https://localhost:5067/",
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/query/, ""),
      },
      "/cmd": {
        secure: false,
        target: "https://localhost:5067/",
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/cmd/, ""),
      },
    },
  },
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
    },
  },
});
