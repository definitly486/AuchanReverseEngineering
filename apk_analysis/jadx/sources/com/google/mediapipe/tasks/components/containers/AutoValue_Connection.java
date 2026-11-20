package com.google.mediapipe.tasks.components.containers;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_Connection extends Connection {
    private final int end;
    private final int start;

    AutoValue_Connection(int i, int i2) {
        this.start = i;
        this.end = i2;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Connection
    public int start() {
        return this.start;
    }

    @Override // com.google.mediapipe.tasks.components.containers.Connection
    public int end() {
        return this.end;
    }

    public String toString() {
        return "Connection{start=" + this.start + ", end=" + this.end + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof Connection) {
            Connection connection = (Connection) obj;
            if (this.start == connection.start() && this.end == connection.end()) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((this.start ^ 1000003) * 1000003) ^ this.end;
    }
}
