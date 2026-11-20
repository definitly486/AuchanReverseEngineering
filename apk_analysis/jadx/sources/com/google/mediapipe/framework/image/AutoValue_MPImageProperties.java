package com.google.mediapipe.framework.image;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_MPImageProperties extends C$AutoValue_MPImageProperties {
    private volatile transient int hashCode;
    private volatile transient boolean hashCode$Memoized;

    AutoValue_MPImageProperties(int i, int i2) {
        super(i, i2);
    }

    @Override // com.google.mediapipe.framework.image.C$AutoValue_MPImageProperties, com.google.mediapipe.framework.image.MPImageProperties
    public int hashCode() {
        if (!this.hashCode$Memoized) {
            synchronized (this) {
                try {
                    if (!this.hashCode$Memoized) {
                        this.hashCode = super.hashCode();
                        this.hashCode$Memoized = true;
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return this.hashCode;
    }

    @Override // com.google.mediapipe.framework.image.C$AutoValue_MPImageProperties
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        return (obj instanceof AutoValue_MPImageProperties) && hashCode() == obj.hashCode() && super.equals(obj);
    }
}
