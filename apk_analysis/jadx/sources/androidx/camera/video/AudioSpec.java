package androidx.camera.video;

import android.util.Range;

/* JADX INFO: loaded from: classes.dex */
public abstract class AudioSpec {
    public static final Range BITRATE_RANGE_AUTO = new Range(0, Integer.MAX_VALUE);
    public static final Range SAMPLE_RATE_RANGE_AUTO = new Range(0, Integer.MAX_VALUE);
    public static final AudioSpec NO_AUDIO = builder().setChannelCount(0).build();

    public abstract Range getBitrate();

    public abstract int getChannelCount();

    public abstract Range getSampleRate();

    public abstract int getSource();

    public abstract int getSourceFormat();

    AudioSpec() {
    }

    public static Builder builder() {
        return new AutoValue_AudioSpec.Builder().setSourceFormat(-1).setSource(-1).setChannelCount(-1).setBitrate(BITRATE_RANGE_AUTO).setSampleRate(SAMPLE_RATE_RANGE_AUTO);
    }

    public static abstract class Builder {
        public abstract AudioSpec build();

        public abstract Builder setBitrate(Range range);

        public abstract Builder setChannelCount(int i);

        public abstract Builder setSampleRate(Range range);

        public abstract Builder setSource(int i);

        Builder() {
        }
    }
}
