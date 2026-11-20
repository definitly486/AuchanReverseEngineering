package com.google.mediapipe.tasks.components.containers;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_AudioData_AudioDataFormat extends AudioData.AudioDataFormat {
    private final int numOfChannels;
    private final float sampleRate;

    private AutoValue_AudioData_AudioDataFormat(int i, float f) {
        this.numOfChannels = i;
        this.sampleRate = f;
    }

    @Override // com.google.mediapipe.tasks.components.containers.AudioData.AudioDataFormat
    public int getNumOfChannels() {
        return this.numOfChannels;
    }

    @Override // com.google.mediapipe.tasks.components.containers.AudioData.AudioDataFormat
    public float getSampleRate() {
        return this.sampleRate;
    }

    public String toString() {
        return "AudioDataFormat{numOfChannels=" + this.numOfChannels + ", sampleRate=" + this.sampleRate + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof AudioData.AudioDataFormat) {
            AudioData.AudioDataFormat audioDataFormat = (AudioData.AudioDataFormat) obj;
            if (this.numOfChannels == audioDataFormat.getNumOfChannels() && Float.floatToIntBits(this.sampleRate) == Float.floatToIntBits(audioDataFormat.getSampleRate())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((this.numOfChannels ^ 1000003) * 1000003) ^ Float.floatToIntBits(this.sampleRate);
    }

    static final class Builder extends AudioData.AudioDataFormat.Builder {
        private Integer numOfChannels;
        private Float sampleRate;

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.components.containers.AudioData.AudioDataFormat.Builder
        public AudioData.AudioDataFormat.Builder setNumOfChannels(int i) {
            this.numOfChannels = Integer.valueOf(i);
            return this;
        }

        @Override // com.google.mediapipe.tasks.components.containers.AudioData.AudioDataFormat.Builder
        public AudioData.AudioDataFormat.Builder setSampleRate(float f) {
            this.sampleRate = Float.valueOf(f);
            return this;
        }

        @Override // com.google.mediapipe.tasks.components.containers.AudioData.AudioDataFormat.Builder
        AudioData.AudioDataFormat autoBuild() {
            String str = "";
            if (this.numOfChannels == null) {
                str = " numOfChannels";
            }
            if (this.sampleRate == null) {
                str = str + " sampleRate";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_AudioData_AudioDataFormat(this.numOfChannels.intValue(), this.sampleRate.floatValue());
        }
    }
}
