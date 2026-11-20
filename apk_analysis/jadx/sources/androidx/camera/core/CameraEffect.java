package androidx.camera.core;

import androidx.camera.core.processing.SurfaceProcessorInternal;
import androidx.core.util.Consumer;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.SurfaceProcessorWithExecutor;
import com.scanflow.datacapture.barinternal.androidx.camera.core.processing.TargetUtils;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.Arrays;
import java.util.List;
import java.util.concurrent.Executor;

/* JADX INFO: loaded from: classes.dex */
public abstract class CameraEffect {
    private static final List SURFACE_PROCESSOR_TARGETS = Arrays.asList(1, 2, 3, 7);
    private final Consumer mErrorListener;
    private final Executor mExecutor;
    private final ImageProcessor mImageProcessor;
    private final int mOutputOption;
    private final SurfaceProcessor mSurfaceProcessor;
    private final int mTargets;
    private final int mTransformation;

    protected CameraEffect(int i, Executor executor, ImageProcessor imageProcessor, Consumer<Throwable> consumer) {
        Preconditions.checkArgument(i == 4, "Currently ImageProcessor can only target IMAGE_CAPTURE.");
        this.mTargets = i;
        this.mTransformation = 0;
        this.mOutputOption = 0;
        this.mExecutor = executor;
        this.mSurfaceProcessor = null;
        this.mImageProcessor = imageProcessor;
        this.mErrorListener = consumer;
    }

    protected CameraEffect(int i, int i2, Executor executor, SurfaceProcessor surfaceProcessor, Consumer<Throwable> consumer) {
        this(i, 0, i2, executor, surfaceProcessor, consumer);
    }

    protected CameraEffect(int i, int i2, int i3, Executor executor, SurfaceProcessor surfaceProcessor, Consumer<Throwable> consumer) {
        TargetUtils.checkSupportedTargets(SURFACE_PROCESSOR_TARGETS, i);
        this.mTargets = i;
        this.mOutputOption = i2;
        this.mTransformation = i3;
        this.mExecutor = executor;
        this.mSurfaceProcessor = surfaceProcessor;
        this.mImageProcessor = null;
        this.mErrorListener = consumer;
    }

    protected CameraEffect(int i, Executor executor, SurfaceProcessor surfaceProcessor, Consumer<Throwable> consumer) {
        this(i, 0, 0, executor, surfaceProcessor, consumer);
    }

    public int getTargets() {
        return this.mTargets;
    }

    public int getTransformation() {
        return this.mTransformation;
    }

    public int getOutputOption() {
        return this.mOutputOption;
    }

    public Executor getExecutor() {
        return this.mExecutor;
    }

    public Consumer<Throwable> getErrorListener() {
        return this.mErrorListener;
    }

    public SurfaceProcessor getSurfaceProcessor() {
        return this.mSurfaceProcessor;
    }

    public ImageProcessor getImageProcessor() {
        return this.mImageProcessor;
    }

    public SurfaceProcessorInternal createSurfaceProcessorInternal() {
        return new SurfaceProcessorWithExecutor(this);
    }
}
