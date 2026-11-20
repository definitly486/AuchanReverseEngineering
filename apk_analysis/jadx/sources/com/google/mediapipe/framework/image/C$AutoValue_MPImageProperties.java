package com.google.mediapipe.framework.image;

/* JADX INFO: renamed from: com.google.mediapipe.framework.image.$AutoValue_MPImageProperties, reason: invalid class name */
/* JADX INFO: loaded from: classes3.dex */
abstract class C$AutoValue_MPImageProperties extends MPImageProperties {
    private final int imageFormat;
    private final int storageType;

    C$AutoValue_MPImageProperties(int i, int i2) {
        this.imageFormat = i;
        this.storageType = i2;
    }

    @Override // com.google.mediapipe.framework.image.MPImageProperties
    public int getImageFormat() {
        return this.imageFormat;
    }

    @Override // com.google.mediapipe.framework.image.MPImageProperties
    public int getStorageType() {
        return this.storageType;
    }

    public String toString() {
        return "MPImageProperties{imageFormat=" + this.imageFormat + ", storageType=" + this.storageType + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof MPImageProperties) {
            MPImageProperties mPImageProperties = (MPImageProperties) obj;
            if (this.imageFormat == mPImageProperties.getImageFormat() && this.storageType == mPImageProperties.getStorageType()) {
                return true;
            }
        }
        return false;
    }

    @Override // com.google.mediapipe.framework.image.MPImageProperties
    public int hashCode() {
        return ((this.imageFormat ^ 1000003) * 1000003) ^ this.storageType;
    }

    /* JADX INFO: renamed from: com.google.mediapipe.framework.image.$AutoValue_MPImageProperties$Builder */
    static class Builder extends MPImageProperties.Builder {
        private Integer imageFormat;
        private Integer storageType;

        Builder() {
        }

        @Override // com.google.mediapipe.framework.image.MPImageProperties.Builder
        MPImageProperties.Builder setImageFormat(int i) {
            this.imageFormat = Integer.valueOf(i);
            return this;
        }

        @Override // com.google.mediapipe.framework.image.MPImageProperties.Builder
        MPImageProperties.Builder setStorageType(int i) {
            this.storageType = Integer.valueOf(i);
            return this;
        }

        @Override // com.google.mediapipe.framework.image.MPImageProperties.Builder
        MPImageProperties build() {
            String str = "";
            if (this.imageFormat == null) {
                str = " imageFormat";
            }
            if (this.storageType == null) {
                str = str + " storageType";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_MPImageProperties(this.imageFormat.intValue(), this.storageType.intValue());
        }
    }
}
