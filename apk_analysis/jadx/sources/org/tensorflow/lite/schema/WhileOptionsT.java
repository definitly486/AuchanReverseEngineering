package org.tensorflow.lite.schema;

/* JADX INFO: loaded from: classes4.dex */
public class WhileOptionsT {
    private int condSubgraphIndex = 0;
    private int bodySubgraphIndex = 0;

    public int getCondSubgraphIndex() {
        return this.condSubgraphIndex;
    }

    public void setCondSubgraphIndex(int i) {
        this.condSubgraphIndex = i;
    }

    public int getBodySubgraphIndex() {
        return this.bodySubgraphIndex;
    }

    public void setBodySubgraphIndex(int i) {
        this.bodySubgraphIndex = i;
    }
}
