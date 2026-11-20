package org.tensorflow.lite.gpu;

import java.lang.reflect.InvocationTargetException;
import org.tensorflow.lite.Delegate;
import org.tensorflow.lite.DelegateFactory;
import org.tensorflow.lite.RuntimeFlavor;

/* JADX INFO: loaded from: classes.dex */
public class GpuDelegateFactory implements DelegateFactory {
    private static final String GPU_DELEGATE_CLASS_NAME = "GpuDelegate";
    private final Options options;

    public static class Options {
        public static final int INFERENCE_PREFERENCE_FAST_SINGLE_ANSWER = 0;
        public static final int INFERENCE_PREFERENCE_SUSTAINED_SPEED = 1;
        private boolean precisionLossAllowed = true;
        boolean quantizedModelsAllowed = true;
        int inferencePreference = 0;
        String serializationDir = null;
        String modelToken = null;
        GpuBackend forceBackend = GpuBackend.UNSET;

        public enum GpuBackend {
            UNSET(0),
            OPENCL(1),
            OPENGL(2);

            private final int value;

            GpuBackend(int i) {
                this.value = i;
            }

            public int value() {
                return this.value;
            }
        }

        public Options setPrecisionLossAllowed(boolean z) {
            this.precisionLossAllowed = z;
            return this;
        }

        public Options setQuantizedModelsAllowed(boolean z) {
            this.quantizedModelsAllowed = z;
            return this;
        }

        public Options setInferencePreference(int i) {
            this.inferencePreference = i;
            return this;
        }

        public Options setSerializationParams(String str, String str2) {
            this.serializationDir = str;
            this.modelToken = str2;
            return this;
        }

        public Options setForceBackend(GpuBackend gpuBackend) {
            this.forceBackend = gpuBackend;
            return this;
        }

        public boolean isPrecisionLossAllowed() {
            return this.precisionLossAllowed;
        }

        public boolean areQuantizedModelsAllowed() {
            return this.quantizedModelsAllowed;
        }

        public int getInferencePreference() {
            return this.inferencePreference;
        }

        public String getSerializationDir() {
            return this.serializationDir;
        }

        public String getModelToken() {
            return this.modelToken;
        }

        public GpuBackend getForceBackend() {
            return this.forceBackend;
        }
    }

    public GpuDelegateFactory() {
        this(new Options());
    }

    public GpuDelegateFactory(Options options) {
        this.options = options;
    }

    /* JADX INFO: renamed from: org.tensorflow.lite.gpu.GpuDelegateFactory$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$org$tensorflow$lite$RuntimeFlavor;

        static {
            int[] iArr = new int[RuntimeFlavor.values().length];
            $SwitchMap$org$tensorflow$lite$RuntimeFlavor = iArr;
            try {
                iArr[RuntimeFlavor.APPLICATION.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$org$tensorflow$lite$RuntimeFlavor[RuntimeFlavor.SYSTEM.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
        }
    }

    @Override // org.tensorflow.lite.DelegateFactory
    public Delegate create(RuntimeFlavor runtimeFlavor) {
        String str;
        int i = AnonymousClass1.$SwitchMap$org$tensorflow$lite$RuntimeFlavor[runtimeFlavor.ordinal()];
        if (i == 1) {
            str = "org.tensorflow.lite.gpu";
        } else if (i == 2) {
            str = "com.google.android.gms.tflite.gpu";
        } else {
            throw new IllegalArgumentException("Unsupported runtime flavor " + runtimeFlavor);
        }
        try {
            return (Delegate) Class.forName(str + "." + GPU_DELEGATE_CLASS_NAME).getDeclaredConstructor(Options.class).newInstance(this.options);
        } catch (ClassNotFoundException | IllegalAccessException | InstantiationException | NoSuchMethodException | InvocationTargetException e) {
            throw new IllegalStateException("Error creating GPU delegate", e);
        }
    }
}
