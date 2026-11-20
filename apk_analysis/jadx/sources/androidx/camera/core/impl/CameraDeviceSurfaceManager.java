package androidx.camera.core.impl;

import android.content.Context;
import android.util.Pair;
import android.util.Size;
import java.util.List;
import java.util.Map;
import java.util.Set;

/* JADX INFO: loaded from: classes.dex */
public interface CameraDeviceSurfaceManager {

    public interface Provider {
        CameraDeviceSurfaceManager newInstance(Context context, Object obj, Set set);
    }

    Pair getSuggestedStreamSpecs(int i, String str, List list, Map map, boolean z, boolean z2);

    SurfaceConfig transformSurfaceConfig(int i, String str, int i2, Size size);
}
