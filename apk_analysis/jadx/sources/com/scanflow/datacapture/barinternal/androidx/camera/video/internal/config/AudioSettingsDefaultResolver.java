package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.config;

import android.util.Range;
import androidx.camera.core.Logger;
import androidx.camera.video.AudioSpec;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.audio.AudioSettings;
import com.scanflow.datacapture.barinternal.androidx.core.util.Supplier;

/* JADX INFO: loaded from: classes.dex */
public final class AudioSettingsDefaultResolver implements Supplier {
    private final AudioSpec mAudioSpec;

    public AudioSettingsDefaultResolver(AudioSpec audioSpec) {
        this.mAudioSpec = audioSpec;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.core.util.Supplier
    public AudioSettings get() {
        int iSelectSampleRateOrNearestSupported;
        int iResolveAudioSource = AudioConfigUtil.resolveAudioSource(this.mAudioSpec);
        int iResolveAudioSourceFormat = AudioConfigUtil.resolveAudioSourceFormat(this.mAudioSpec);
        int channelCount = this.mAudioSpec.getChannelCount();
        if (channelCount == -1) {
            Logger.d("DefAudioResolver", "Using fallback AUDIO channel count: 1");
            channelCount = 1;
        } else {
            Logger.d("DefAudioResolver", "Using supplied AUDIO channel count: " + channelCount);
        }
        Range sampleRate = this.mAudioSpec.getSampleRate();
        if (AudioSpec.SAMPLE_RATE_RANGE_AUTO.equals(sampleRate)) {
            StringBuilder sb = new StringBuilder();
            sb.append("Using fallback AUDIO sample rate: ");
            iSelectSampleRateOrNearestSupported = 44100;
            sb.append(44100);
            sb.append("Hz");
            Logger.d("DefAudioResolver", sb.toString());
        } else {
            iSelectSampleRateOrNearestSupported = AudioConfigUtil.selectSampleRateOrNearestSupported(sampleRate, channelCount, iResolveAudioSourceFormat, ((Integer) sampleRate.getUpper()).intValue());
            Logger.d("DefAudioResolver", "Using AUDIO sample rate resolved from AudioSpec: " + iSelectSampleRateOrNearestSupported + "Hz");
        }
        return AudioSettings.builder().setAudioSource(iResolveAudioSource).setAudioFormat(iResolveAudioSourceFormat).setChannelCount(channelCount).setSampleRate(iSelectSampleRateOrNearestSupported).build();
    }
}
