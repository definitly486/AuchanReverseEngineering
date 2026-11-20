package androidx.camera.video;

import android.util.Size;
import androidx.camera.core.DynamicRange;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.VideoValidatedEncoderProfilesProxy;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
public interface VideoCapabilities {
    public static final VideoCapabilities EMPTY = new VideoCapabilities() { // from class: androidx.camera.video.VideoCapabilities.1
        @Override // androidx.camera.video.VideoCapabilities
        public boolean isQualitySupported(Quality quality, DynamicRange dynamicRange) {
            return false;
        }

        @Override // androidx.camera.video.VideoCapabilities
        public boolean isStabilizationSupported() {
            return false;
        }

        @Override // androidx.camera.video.VideoCapabilities
        public Set getSupportedDynamicRanges() {
            return new HashSet();
        }

        @Override // androidx.camera.video.VideoCapabilities
        public List getSupportedQualities(DynamicRange dynamicRange) {
            return new ArrayList();
        }
    };

    Set<DynamicRange> getSupportedDynamicRanges();

    List<Quality> getSupportedQualities(DynamicRange dynamicRange);

    boolean isQualitySupported(Quality quality, DynamicRange dynamicRange);

    default boolean isStabilizationSupported() {
        return false;
    }

    default VideoValidatedEncoderProfilesProxy getProfiles(Quality quality, DynamicRange dynamicRange) {
        return null;
    }

    default VideoValidatedEncoderProfilesProxy findNearestHigherSupportedEncoderProfilesFor(Size size, DynamicRange dynamicRange) {
        return null;
    }

    default Quality findNearestHigherSupportedQualityFor(Size size, DynamicRange dynamicRange) {
        return Quality.NONE;
    }
}
