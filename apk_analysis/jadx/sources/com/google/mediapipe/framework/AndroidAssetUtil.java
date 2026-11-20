package com.google.mediapipe.framework;

import android.content.Context;
import android.content.res.AssetManager;
import com.google.common.io.ByteStreams;
import java.io.IOException;
import java.io.InputStream;

/* JADX INFO: loaded from: classes3.dex */
public final class AndroidAssetUtil {
    private static native boolean nativeInitializeAssetManager(Context context, String str);

    public static byte[] getAssetBytes(AssetManager assetManager, String str) {
        try {
            InputStream inputStreamOpen = assetManager.open(str);
            byte[] byteArray = ByteStreams.toByteArray(inputStreamOpen);
            inputStreamOpen.close();
            return byteArray;
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static synchronized boolean initializeNativeAssetManager(Context context) {
        return nativeInitializeAssetManager(context, context.getCacheDir().getAbsolutePath());
    }

    private AndroidAssetUtil() {
    }
}
