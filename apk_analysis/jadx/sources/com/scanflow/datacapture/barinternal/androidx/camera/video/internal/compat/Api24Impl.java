package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.compat;

import android.media.AudioRecord;
import android.media.AudioRecordingConfiguration;
import android.media.AudioTimestamp;

/* JADX INFO: loaded from: classes.dex */
public abstract class Api24Impl {
    public static int getTimestamp(AudioRecord audioRecord, AudioTimestamp audioTimestamp, int i) {
        return audioRecord.getTimestamp(audioTimestamp, i);
    }

    public static int getClientAudioSessionId(AudioRecordingConfiguration audioRecordingConfiguration) {
        return audioRecordingConfiguration.getClientAudioSessionId();
    }
}
