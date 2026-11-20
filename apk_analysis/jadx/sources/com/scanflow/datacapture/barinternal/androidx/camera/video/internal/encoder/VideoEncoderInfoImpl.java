package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder;

import android.media.MediaCodecInfo;
import android.util.Range;
import androidx.arch.core.util.Function;
import androidx.camera.core.Logger;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.utils.CodecUtil;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.workaround.VideoEncoderInfoWrapper;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class VideoEncoderInfoImpl extends EncoderInfoImpl implements VideoEncoderInfo {
    public static final Function FINDER = new Function() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderInfoImpl$$ExternalSyntheticLambda0
        @Override // androidx.arch.core.util.Function
        public final Object apply(Object obj) {
            return VideoEncoderInfoImpl.$r8$lambda$_nnGq_tAR9fPJy9Jh_hmJTKcDJo((VideoEncoderConfig) obj);
        }
    };
    private final MediaCodecInfo.VideoCapabilities mVideoCapabilities;

    public static /* synthetic */ VideoEncoderInfo $r8$lambda$_nnGq_tAR9fPJy9Jh_hmJTKcDJo(VideoEncoderConfig videoEncoderConfig) {
        try {
            return VideoEncoderInfoWrapper.from(from(videoEncoderConfig), null);
        } catch (InvalidConfigException e) {
            Logger.w("VideoEncoderInfoImpl", "Unable to find a VideoEncoderInfoImpl", e);
            return null;
        }
    }

    public static VideoEncoderInfoImpl from(VideoEncoderConfig videoEncoderConfig) {
        return new VideoEncoderInfoImpl(CodecUtil.findCodecAndGetCodecInfo(videoEncoderConfig), videoEncoderConfig.getMimeType());
    }

    VideoEncoderInfoImpl(MediaCodecInfo mediaCodecInfo, String str) {
        super(mediaCodecInfo, str);
        MediaCodecInfo.VideoCapabilities videoCapabilities = this.mCodecCapabilities.getVideoCapabilities();
        Objects.requireNonNull(videoCapabilities);
        this.mVideoCapabilities = videoCapabilities;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderInfo
    public boolean canSwapWidthHeight() {
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderInfo
    public boolean isSizeSupported(int i, int i2) {
        return this.mVideoCapabilities.isSizeSupported(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderInfo
    public Range getSupportedWidths() {
        return this.mVideoCapabilities.getSupportedWidths();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderInfo
    public Range getSupportedHeights() {
        return this.mVideoCapabilities.getSupportedHeights();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderInfo
    public Range getSupportedWidthsFor(int i) {
        try {
            return this.mVideoCapabilities.getSupportedWidthsFor(i);
        } catch (Throwable th) {
            throw toIllegalArgumentException(th);
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderInfo
    public Range getSupportedHeightsFor(int i) {
        try {
            return this.mVideoCapabilities.getSupportedHeightsFor(i);
        } catch (Throwable th) {
            throw toIllegalArgumentException(th);
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderInfo
    public int getWidthAlignment() {
        return this.mVideoCapabilities.getWidthAlignment();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderInfo
    public int getHeightAlignment() {
        return this.mVideoCapabilities.getHeightAlignment();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderInfo
    public Range getSupportedBitrateRange() {
        return this.mVideoCapabilities.getBitrateRange();
    }

    private static IllegalArgumentException toIllegalArgumentException(Throwable th) {
        if (th instanceof IllegalArgumentException) {
            return (IllegalArgumentException) th;
        }
        return new IllegalArgumentException(th);
    }
}
