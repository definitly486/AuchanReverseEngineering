package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.config;

import androidx.camera.core.impl.EncoderProfilesProxy;

/* JADX INFO: loaded from: classes.dex */
public abstract class VideoMimeInfo extends MimeInfo {

    public static abstract class Builder extends MimeInfo.Builder {
        public abstract VideoMimeInfo build();

        public abstract Builder setCompatibleVideoProfile(EncoderProfilesProxy.VideoProfileProxy videoProfileProxy);
    }

    public abstract EncoderProfilesProxy.VideoProfileProxy getCompatibleVideoProfile();

    public static Builder builder(String str) {
        return (Builder) new AutoValue_VideoMimeInfo.Builder().setMimeType(str).setProfile(-1);
    }
}
