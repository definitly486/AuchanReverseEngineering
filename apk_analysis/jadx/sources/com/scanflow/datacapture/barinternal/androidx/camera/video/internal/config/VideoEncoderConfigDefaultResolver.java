package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.config;

import android.util.Range;
import android.util.Size;
import androidx.camera.core.DynamicRange;
import androidx.camera.core.Logger;
import androidx.camera.core.SurfaceRequest;
import androidx.camera.core.impl.Timebase;
import androidx.camera.video.VideoSpec;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderConfig;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.utils.DynamicRangeUtil;
import com.scanflow.datacapture.barinternal.androidx.core.util.Supplier;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class VideoEncoderConfigDefaultResolver implements Supplier {
    private final DynamicRange mDynamicRange;
    private final Range mExpectedFrameRateRange;
    private final Timebase mInputTimebase;
    private final String mMimeType;
    private final Size mSurfaceSize;
    private final VideoSpec mVideoSpec;
    private static final Size VIDEO_SIZE_BASE = new Size(1280, 720);
    private static final Range VALID_FRAME_RATE_RANGE = new Range(1, 60);

    public VideoEncoderConfigDefaultResolver(String str, Timebase timebase, VideoSpec videoSpec, Size size, DynamicRange dynamicRange, Range range) {
        this.mMimeType = str;
        this.mInputTimebase = timebase;
        this.mVideoSpec = videoSpec;
        this.mSurfaceSize = size;
        this.mDynamicRange = dynamicRange;
        this.mExpectedFrameRateRange = range;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.core.util.Supplier
    public VideoEncoderConfig get() {
        int iResolveFrameRate = resolveFrameRate();
        Logger.d("VidEncCfgDefaultRslvr", "Resolved VIDEO frame rate: " + iResolveFrameRate + "fps");
        Range bitrate = this.mVideoSpec.getBitrate();
        Logger.d("VidEncCfgDefaultRslvr", "Using fallback VIDEO bitrate");
        int bitDepth = this.mDynamicRange.getBitDepth();
        int width = this.mSurfaceSize.getWidth();
        Size size = VIDEO_SIZE_BASE;
        int iScaleAndClampBitrate = VideoConfigUtil.scaleAndClampBitrate(14000000, bitDepth, 8, iResolveFrameRate, 30, width, size.getWidth(), this.mSurfaceSize.getHeight(), size.getHeight(), bitrate);
        int iDynamicRangeToCodecProfileLevelForMime = DynamicRangeUtil.dynamicRangeToCodecProfileLevelForMime(this.mMimeType, this.mDynamicRange);
        return VideoEncoderConfig.builder().setMimeType(this.mMimeType).setInputTimebase(this.mInputTimebase).setResolution(this.mSurfaceSize).setBitrate(iScaleAndClampBitrate).setFrameRate(iResolveFrameRate).setProfile(iDynamicRangeToCodecProfileLevelForMime).setDataSpace(VideoConfigUtil.mimeAndProfileToEncoderDataSpace(this.mMimeType, iDynamicRangeToCodecProfileLevelForMime)).build();
    }

    private int resolveFrameRate() {
        Range range = this.mExpectedFrameRateRange;
        Range range2 = SurfaceRequest.FRAME_RATE_RANGE_UNSPECIFIED;
        int iIntValue = !Objects.equals(range, range2) ? ((Integer) VALID_FRAME_RATE_RANGE.clamp((Integer) this.mExpectedFrameRateRange.getUpper())).intValue() : 30;
        Logger.d("VidEncCfgDefaultRslvr", String.format("Default resolved frame rate: %dfps. [Expected operating range: %s]", Integer.valueOf(iIntValue), Objects.equals(this.mExpectedFrameRateRange, range2) ? this.mExpectedFrameRateRange : "<UNSPECIFIED>"));
        return iIntValue;
    }
}
