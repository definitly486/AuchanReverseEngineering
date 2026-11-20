package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.config;

import android.util.Range;
import android.util.Size;
import androidx.camera.core.DynamicRange;
import androidx.camera.core.Logger;
import androidx.camera.core.SurfaceRequest;
import androidx.camera.core.impl.EncoderProfilesProxy;
import androidx.camera.core.impl.Timebase;
import androidx.camera.video.VideoSpec;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderConfig;
import com.scanflow.datacapture.barinternal.androidx.core.util.Supplier;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class VideoEncoderConfigVideoProfileResolver implements Supplier {
    private final DynamicRange mDynamicRange;
    private final Range mExpectedFrameRateRange;
    private final Timebase mInputTimebase;
    private final String mMimeType;
    private final Size mSurfaceSize;
    private final EncoderProfilesProxy.VideoProfileProxy mVideoProfile;
    private final VideoSpec mVideoSpec;

    public VideoEncoderConfigVideoProfileResolver(String str, Timebase timebase, VideoSpec videoSpec, Size size, EncoderProfilesProxy.VideoProfileProxy videoProfileProxy, DynamicRange dynamicRange, Range range) {
        this.mMimeType = str;
        this.mInputTimebase = timebase;
        this.mVideoSpec = videoSpec;
        this.mSurfaceSize = size;
        this.mVideoProfile = videoProfileProxy;
        this.mDynamicRange = dynamicRange;
        this.mExpectedFrameRateRange = range;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.core.util.Supplier
    public VideoEncoderConfig get() {
        int iResolveFrameRate = resolveFrameRate();
        Logger.d("VidEncVdPrflRslvr", "Resolved VIDEO frame rate: " + iResolveFrameRate + "fps");
        Range bitrate = this.mVideoSpec.getBitrate();
        Logger.d("VidEncVdPrflRslvr", "Using resolved VIDEO bitrate from EncoderProfiles");
        int iScaleAndClampBitrate = VideoConfigUtil.scaleAndClampBitrate(this.mVideoProfile.getBitrate(), this.mDynamicRange.getBitDepth(), this.mVideoProfile.getBitDepth(), iResolveFrameRate, this.mVideoProfile.getFrameRate(), this.mSurfaceSize.getWidth(), this.mVideoProfile.getWidth(), this.mSurfaceSize.getHeight(), this.mVideoProfile.getHeight(), bitrate);
        int profile = this.mVideoProfile.getProfile();
        return VideoEncoderConfig.builder().setMimeType(this.mMimeType).setInputTimebase(this.mInputTimebase).setResolution(this.mSurfaceSize).setBitrate(iScaleAndClampBitrate).setFrameRate(iResolveFrameRate).setProfile(profile).setDataSpace(VideoConfigUtil.mimeAndProfileToEncoderDataSpace(this.mMimeType, profile)).build();
    }

    private int resolveFrameRate() {
        int frameRate = this.mVideoProfile.getFrameRate();
        Range range = this.mExpectedFrameRateRange;
        Range range2 = SurfaceRequest.FRAME_RATE_RANGE_UNSPECIFIED;
        int iIntValue = !Objects.equals(range, range2) ? ((Integer) this.mExpectedFrameRateRange.clamp(Integer.valueOf(frameRate))).intValue() : frameRate;
        Logger.d("VidEncVdPrflRslvr", String.format("Resolved frame rate %dfps [Video profile frame rate: %dfps, Expected operating range: %s]", Integer.valueOf(iIntValue), Integer.valueOf(frameRate), Objects.equals(this.mExpectedFrameRateRange, range2) ? this.mExpectedFrameRateRange : "<UNSPECIFIED>"));
        return iIntValue;
    }
}
