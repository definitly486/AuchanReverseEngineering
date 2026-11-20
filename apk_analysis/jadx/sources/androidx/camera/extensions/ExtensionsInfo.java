package androidx.camera.extensions;

import androidx.camera.core.CameraProvider;

/* JADX INFO: loaded from: classes.dex */
final class ExtensionsInfo {
    private final CameraProvider mCameraProvider;
    private VendorExtenderFactory mVendorExtenderFactory = new VendorExtenderFactory() { // from class: androidx.camera.extensions.ExtensionsInfo$$ExternalSyntheticLambda0
    };

    ExtensionsInfo(CameraProvider cameraProvider) {
        this.mCameraProvider = cameraProvider;
    }
}
