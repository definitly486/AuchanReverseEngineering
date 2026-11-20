package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.config;

import android.util.Range;
import androidx.camera.core.Logger;
import androidx.camera.core.impl.Timebase;
import androidx.camera.video.AudioSpec;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSettings;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.AudioEncoderConfig;
import com.scanflow.datacapture.barinternal.androidx.core.util.Supplier;

/* JADX INFO: loaded from: classes.dex */
public final class AudioEncoderConfigDefaultResolver implements Supplier {
    private final int mAudioProfile;
    private final AudioSettings mAudioSettings;
    private final AudioSpec mAudioSpec;
    private final Timebase mInputTimeBase;
    private final String mMimeType;

    public AudioEncoderConfigDefaultResolver(String str, int i, Timebase timebase, AudioSpec audioSpec, AudioSettings audioSettings) {
        this.mMimeType = str;
        this.mAudioProfile = i;
        this.mInputTimeBase = timebase;
        this.mAudioSpec = audioSpec;
        this.mAudioSettings = audioSettings;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.core.util.Supplier
    public AudioEncoderConfig get() {
        Range bitrate = this.mAudioSpec.getBitrate();
        Logger.d("AudioEncCfgDefaultRslvr", "Using fallback AUDIO bitrate");
        return AudioEncoderConfig.builder().setMimeType(this.mMimeType).setProfile(this.mAudioProfile).setInputTimebase(this.mInputTimeBase).setChannelCount(this.mAudioSettings.getChannelCount()).setSampleRate(this.mAudioSettings.getSampleRate()).setBitrate(AudioConfigUtil.scaleAndClampBitrate(156000, this.mAudioSettings.getChannelCount(), 2, this.mAudioSettings.getSampleRate(), 48000, bitrate)).build();
    }
}
