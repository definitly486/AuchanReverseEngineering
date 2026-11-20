package com.google.mediapipe.tasks.components.containers;

import android.media.AudioFormat;
import android.media.AudioRecord;
import com.google.auto.value.AutoValue;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.nio.FloatBuffer;

/* JADX INFO: loaded from: classes3.dex */
public class AudioData {
    private static final String TAG = "AudioData";
    private final FloatRingBuffer buffer;
    private final AudioDataFormat format;

    public static AudioData create(AudioDataFormat audioDataFormat, int i) {
        return new AudioData(audioDataFormat, i);
    }

    public static AudioData create(AudioFormat audioFormat, int i) {
        return new AudioData(AudioDataFormat.create(audioFormat), i);
    }

    @AutoValue
    public static abstract class AudioDataFormat {
        private static final int DEFAULT_NUM_OF_CHANNELS = 1;

        public abstract int getNumOfChannels();

        public abstract float getSampleRate();

        public static AudioDataFormat create(AudioFormat audioFormat) {
            return builder().setNumOfChannels(audioFormat.getChannelCount()).setSampleRate(audioFormat.getSampleRate()).build();
        }

        public static Builder builder() {
            return new AutoValue_AudioData_AudioDataFormat.Builder().setNumOfChannels(1);
        }

        @AutoValue.Builder
        public static abstract class Builder {
            abstract AudioDataFormat autoBuild();

            public abstract Builder setNumOfChannels(int i);

            public abstract Builder setSampleRate(float f);

            public AudioDataFormat build() {
                AudioDataFormat audioDataFormatAutoBuild = autoBuild();
                if (audioDataFormatAutoBuild.getNumOfChannels() <= 0) {
                    throw new IllegalArgumentException("Number of channels should be greater than 0");
                }
                if (audioDataFormatAutoBuild.getSampleRate() > 0.0f) {
                    return audioDataFormatAutoBuild;
                }
                throw new IllegalArgumentException("Sample rate should be greater than 0");
            }
        }
    }

    public void load(float[] fArr) {
        load(fArr, 0, fArr.length);
    }

    public void load(float[] fArr, int i, int i2) {
        if (i2 % this.format.getNumOfChannels() != 0) {
            throw new IllegalArgumentException(String.format("Size (%d) needs to be a multiplier of the number of channels (%d)", Integer.valueOf(i2), Integer.valueOf(this.format.getNumOfChannels())));
        }
        this.buffer.load(fArr, i, i2);
    }

    public void load(short[] sArr) {
        load(sArr, 0, sArr.length);
    }

    public void load(short[] sArr, int i, int i2) {
        if (i + i2 > sArr.length) {
            throw new IllegalArgumentException(String.format("Index out of range. offset (%d) + size (%d) should <= newData.length (%d)", Integer.valueOf(i), Integer.valueOf(i2), Integer.valueOf(sArr.length)));
        }
        float[] fArr = new float[i2];
        for (int i3 = 0; i3 < i2; i3++) {
            fArr[i3] = (sArr[i3 + i] * 1.0f) / 32767.0f;
        }
        load(fArr);
    }

    public int load(AudioRecord audioRecord) {
        int i;
        if (!this.format.equals(AudioDataFormat.create(audioRecord.getFormat()))) {
            throw new IllegalArgumentException("Incompatible audio format.");
        }
        if (audioRecord.getAudioFormat() == 4) {
            int channelCount = audioRecord.getChannelCount() * audioRecord.getBufferSizeInFrames();
            float[] fArr = new float[channelCount];
            i = audioRecord.read(fArr, 0, channelCount, 1);
            if (i > 0) {
                load(fArr, 0, i);
                return i;
            }
        } else if (audioRecord.getAudioFormat() == 2) {
            int channelCount2 = audioRecord.getChannelCount() * audioRecord.getBufferSizeInFrames();
            short[] sArr = new short[channelCount2];
            i = audioRecord.read(sArr, 0, channelCount2, 1);
            if (i > 0) {
                load(sArr, 0, i);
                return i;
            }
        } else {
            throw new IllegalArgumentException("Unsupported encoding. Requires ENCODING_PCM_16BIT or ENCODING_PCM_FLOAT.");
        }
        if (i == -6) {
            throw new IllegalStateException("AudioRecord.ERROR_DEAD_OBJECT");
        }
        if (i == -3) {
            throw new IllegalStateException("AudioRecord.ERROR_INVALID_OPERATION");
        }
        if (i == -2) {
            throw new IllegalStateException("AudioRecord.ERROR_BAD_VALUE");
        }
        if (i != -1) {
            return 0;
        }
        throw new IllegalStateException("AudioRecord.ERROR");
    }

    public float[] getBuffer() {
        float[] fArr = new float[this.buffer.getCapacity()];
        this.buffer.getBuffer().asFloatBuffer().get(fArr);
        return fArr;
    }

    public AudioDataFormat getFormat() {
        return this.format;
    }

    public int getBufferLength() {
        return this.buffer.getCapacity() / this.format.getNumOfChannels();
    }

    private AudioData(AudioDataFormat audioDataFormat, int i) {
        this.format = audioDataFormat;
        this.buffer = new FloatRingBuffer(i * audioDataFormat.getNumOfChannels());
    }

    private static class FloatRingBuffer {
        private final float[] buffer;
        private int nextIndex = 0;

        public FloatRingBuffer(int i) {
            this.buffer = new float[i];
        }

        public void load(float[] fArr, int i, int i2) {
            if (i + i2 > fArr.length) {
                throw new IllegalArgumentException(String.format("Index out of range. offset (%d) + size (%d) should <= newData.length (%d)", Integer.valueOf(i), Integer.valueOf(i2), Integer.valueOf(fArr.length)));
            }
            float[] fArr2 = this.buffer;
            if (i2 > fArr2.length) {
                i += i2 - fArr2.length;
                i2 = fArr2.length;
            }
            int i3 = this.nextIndex;
            if (i3 + i2 < fArr2.length) {
                System.arraycopy(fArr, i, fArr2, i3, i2);
            } else {
                int length = fArr2.length - i3;
                System.arraycopy(fArr, i, fArr2, i3, length);
                System.arraycopy(fArr, i + length, this.buffer, 0, i2 - length);
            }
            this.nextIndex = (this.nextIndex + i2) % this.buffer.length;
        }

        public ByteBuffer getBuffer() {
            ByteBuffer byteBufferAllocate = ByteBuffer.allocate(this.buffer.length * 4);
            byteBufferAllocate.order(ByteOrder.nativeOrder());
            FloatBuffer floatBufferAsFloatBuffer = byteBufferAllocate.asFloatBuffer();
            float[] fArr = this.buffer;
            int i = this.nextIndex;
            floatBufferAsFloatBuffer.put(fArr, i, fArr.length - i);
            floatBufferAsFloatBuffer.put(this.buffer, 0, this.nextIndex);
            byteBufferAllocate.rewind();
            return byteBufferAllocate;
        }

        public int getCapacity() {
            return this.buffer.length;
        }
    }
}
