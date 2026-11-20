package com.google.common.graph;

import com.google.common.annotations.Beta;
import java.util.Set;

/* JADX INFO: loaded from: classes2.dex */
@Beta
abstract class GraphsBridgeMethods {
    GraphsBridgeMethods() {
    }

    public static <N> Graph<N> transitiveClosure(Graph<N> graph) {
        return Graphs.transitiveClosure((Graph) graph);
    }

    public static <N> Set<N> reachableNodes(Graph<N> graph, N n) {
        return Graphs.reachableNodes((Graph) graph, (Object) n);
    }
}
