package androidx.camera.extensions;

import androidx.camera.core.CameraProvider;
import androidx.camera.core.Logger;
import androidx.camera.extensions.impl.InitializerImpl;
import androidx.concurrent.futures.CallbackToFutureAdapter;

/* JADX INFO: loaded from: classes.dex */
public final class ExtensionsManager {
    private static final Object EXTENSIONS_LOCK = new Object();
    private static ExtensionsManager sExtensionsManager;
    private final ExtensionsAvailability mExtensionsAvailability;
    private final ExtensionsInfo mExtensionsInfo;

    enum ExtensionsAvailability {
        LIBRARY_AVAILABLE,
        LIBRARY_UNAVAILABLE_ERROR_LOADING,
        LIBRARY_UNAVAILABLE_MISSING_IMPLEMENTATION,
        NONE
    }

    /* JADX INFO: renamed from: androidx.camera.extensions.ExtensionsManager$1, reason: invalid class name */
    class AnonymousClass1 implements InitializerImpl.OnExtensionsInitializedCallback {
        final /* synthetic */ CameraProvider val$cameraProvider;
        final /* synthetic */ CallbackToFutureAdapter.Completer val$completer;

        AnonymousClass1(CallbackToFutureAdapter.Completer completer, CameraProvider cameraProvider) {
            this.val$completer = completer;
            this.val$cameraProvider = cameraProvider;
        }

        public void onSuccess() {
            Logger.d("ExtensionsManager", "Successfully initialized extensions");
            this.val$completer.set(ExtensionsManager.getOrCreateExtensionsManager(ExtensionsAvailability.LIBRARY_AVAILABLE, this.val$cameraProvider));
        }

        public void onFailure(int i) {
            Logger.e("ExtensionsManager", "Failed to initialize extensions");
            this.val$completer.set(ExtensionsManager.getOrCreateExtensionsManager(ExtensionsAvailability.LIBRARY_UNAVAILABLE_ERROR_LOADING, this.val$cameraProvider));
        }
    }

    /* JADX INFO: renamed from: androidx.camera.extensions.ExtensionsManager$2, reason: invalid class name */
    class AnonymousClass2 implements InitializerImpl.OnExtensionsDeinitializedCallback {
        final /* synthetic */ CallbackToFutureAdapter.Completer val$completer;

        AnonymousClass2(CallbackToFutureAdapter.Completer completer) {
            this.val$completer = completer;
        }

        public void onSuccess() {
            this.val$completer.set(null);
        }

        public void onFailure(int i) {
            this.val$completer.setException(new Exception("Failed to deinitialize extensions."));
        }
    }

    static ExtensionsManager getOrCreateExtensionsManager(ExtensionsAvailability extensionsAvailability, CameraProvider cameraProvider) {
        synchronized (EXTENSIONS_LOCK) {
            try {
                ExtensionsManager extensionsManager = sExtensionsManager;
                if (extensionsManager != null) {
                    return extensionsManager;
                }
                ExtensionsManager extensionsManager2 = new ExtensionsManager(extensionsAvailability, cameraProvider);
                sExtensionsManager = extensionsManager2;
                return extensionsManager2;
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    private ExtensionsManager(ExtensionsAvailability extensionsAvailability, CameraProvider cameraProvider) {
        this.mExtensionsAvailability = extensionsAvailability;
        this.mExtensionsInfo = new ExtensionsInfo(cameraProvider);
    }
}
