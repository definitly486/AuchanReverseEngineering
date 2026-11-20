package androidx.camera.video.internal.compat.quirk;

import android.os.Build;
import android.util.Range;
import android.util.Size;
import androidx.arch.core.util.Function;
import androidx.camera.core.impl.CameraInfoInternal;
import androidx.camera.core.impl.EncoderProfilesProvider;
import androidx.camera.core.impl.EncoderProfilesProxy;
import androidx.camera.core.impl.Quirk;
import androidx.camera.video.VideoSpec;
import com.scanflow.datacapture.barinternal.androidx.camera.core.internal.utils.SizeUtil;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.config.VideoConfigUtil;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.VideoEncoderInfo;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.utils.EncoderProfilesUtil;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

/* JADX INFO: loaded from: classes.dex */
public class ExtraSupportedQualityQuirk implements Quirk {
    static boolean load() {
        return isMotoC();
    }

    private static boolean isMotoC() {
        return "motorola".equalsIgnoreCase(Build.BRAND) && "moto c".equalsIgnoreCase(Build.MODEL);
    }

    public Map getExtraEncoderProfiles(CameraInfoInternal cameraInfoInternal, EncoderProfilesProvider encoderProfilesProvider, Function function) {
        if (isMotoC()) {
            return getExtraEncoderProfilesForMotoC(cameraInfoInternal, encoderProfilesProvider, function);
        }
        return Collections.EMPTY_MAP;
    }

    private Map getExtraEncoderProfilesForMotoC(CameraInfoInternal cameraInfoInternal, EncoderProfilesProvider encoderProfilesProvider, Function function) {
        EncoderProfilesProxy all;
        EncoderProfilesProxy.VideoProfileProxy firstVideoProfile;
        if (!"1".equals(cameraInfoInternal.getCameraId()) || encoderProfilesProvider.hasProfile(4) || (firstVideoProfile = EncoderProfilesUtil.getFirstVideoProfile((all = encoderProfilesProvider.getAll(1)))) == null) {
            return null;
        }
        Range supportedBitrateRange = getSupportedBitrateRange(firstVideoProfile, function);
        Size size = SizeUtil.RESOLUTION_480P;
        EncoderProfilesProxy.ImmutableEncoderProfilesProxy immutableEncoderProfilesProxyCreate = EncoderProfilesProxy.ImmutableEncoderProfilesProxy.create(all.getDefaultDurationSeconds(), all.getRecommendedFileFormat(), all.getAudioProfiles(), Collections.singletonList(EncoderProfilesUtil.deriveVideoProfile(firstVideoProfile, size, supportedBitrateRange)));
        HashMap map = new HashMap();
        map.put(4, immutableEncoderProfilesProxyCreate);
        if (SizeUtil.getArea(size) > SizeUtil.getArea(new Size(firstVideoProfile.getWidth(), firstVideoProfile.getHeight()))) {
            map.put(1, immutableEncoderProfilesProxyCreate);
        }
        return map;
    }

    private static Range getSupportedBitrateRange(EncoderProfilesProxy.VideoProfileProxy videoProfileProxy, Function function) {
        VideoEncoderInfo videoEncoderInfo = (VideoEncoderInfo) function.apply(VideoConfigUtil.toVideoEncoderConfig(videoProfileProxy));
        if (videoEncoderInfo != null) {
            return videoEncoderInfo.getSupportedBitrateRange();
        }
        return VideoSpec.BITRATE_RANGE_AUTO;
    }
}
