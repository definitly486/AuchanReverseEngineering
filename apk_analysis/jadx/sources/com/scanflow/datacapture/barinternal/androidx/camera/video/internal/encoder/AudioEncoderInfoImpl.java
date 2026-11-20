package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder;

import android.media.MediaCodecInfo;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class AudioEncoderInfoImpl extends EncoderInfoImpl implements EncoderInfo {
    private final MediaCodecInfo.AudioCapabilities mAudioCapabilities;

    AudioEncoderInfoImpl(MediaCodecInfo mediaCodecInfo, String str) {
        super(mediaCodecInfo, str);
        MediaCodecInfo.AudioCapabilities audioCapabilities = this.mCodecCapabilities.getAudioCapabilities();
        Objects.requireNonNull(audioCapabilities);
        this.mAudioCapabilities = audioCapabilities;
    }
}
