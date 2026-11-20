package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.Edge;

/* JADX INFO: loaded from: classes.dex */
final class AutoValue_ProcessingNode_In extends ProcessingNode.In {
    private final Edge edge;
    private final int inputFormat;
    private final int outputFormat;
    private final Edge postviewEdge;

    AutoValue_ProcessingNode_In(Edge edge, Edge edge2, int i, int i2) {
        if (edge == null) {
            throw new NullPointerException("Null edge");
        }
        this.edge = edge;
        if (edge2 == null) {
            throw new NullPointerException("Null postviewEdge");
        }
        this.postviewEdge = edge2;
        this.inputFormat = i;
        this.outputFormat = i2;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode.In
    Edge getEdge() {
        return this.edge;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode.In
    Edge getPostviewEdge() {
        return this.postviewEdge;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode.In
    int getInputFormat() {
        return this.inputFormat;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture.ProcessingNode.In
    int getOutputFormat() {
        return this.outputFormat;
    }

    public String toString() {
        return "In{edge=" + this.edge + ", postviewEdge=" + this.postviewEdge + ", inputFormat=" + this.inputFormat + ", outputFormat=" + this.outputFormat + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof ProcessingNode.In) {
            ProcessingNode.In in = (ProcessingNode.In) obj;
            if (this.edge.equals(in.getEdge()) && this.postviewEdge.equals(in.getPostviewEdge()) && this.inputFormat == in.getInputFormat() && this.outputFormat == in.getOutputFormat()) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((((this.edge.hashCode() ^ 1000003) * 1000003) ^ this.postviewEdge.hashCode()) * 1000003) ^ this.inputFormat) * 1000003) ^ this.outputFormat;
    }
}
