using System;
using System.Collections.Generic;

class Graph {
    private int V; // จำนวนโหนดในกราฟ
    private List<int>[] adj; // เก็บเส้นเชื่อมโหนด

    public Graph(int v) {
        V = v;
        adj = new List<int>[V];
        for (int i = 0; i < V; i++) {
            adj[i] = new List<int>();
        }
    }

    // เพิ่มเส้นเชื่อมโหนด
    public void AddEdge(int u, int v) {
        adj[u].Add(v);
    }

    // ค้นหาโหนดต่อไปที่เชื่อมกับโหนด u
    private bool DFS(int u, int target, bool[] visited) {
        if (u == target) {
            return true;
        }
        visited[u] = true;
        foreach (int v in adj[u]) {
            if (!visited[v]) {
                if (DFS(v, target, visited)) {
                    return true;
                }
            }
        }
        return false;
    }

    // ตรวจสอบว่ามีเส้นทางจาก u ไปยัง v หรือไม่
    public bool IsReachable(int u, int v) {
        bool[] visited = new bool[V];
        return DFS(u, v, visited);
    }
}

class Program {
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        Graph g = new Graph(n);
        while (true) {
            int u = int.Parse(Console.ReadLine());
            if (u < 0 || u >= n) {
                break;
            }
            int v = int.Parse(Console.ReadLine());
            if (v < 0 || v >= n) {
                break;
            }
            g.AddEdge(u, v);
        }
        while (true) {
            int u = int.Parse(Console.ReadLine());
            if (u < 0 || u >= n) {
                break;
            }
            int v = int.Parse(Console.ReadLine());
            if (v < 0 || v >= n) {
                break;
            }
            if (g.IsReachable(u, v)) {
                Console.WriteLine("Reachable");
            } else {
                Console.WriteLine("Unreachable");
            }
        }
    }
}
