package com.scanflow.datacapture.barinternal;

import android.app.Activity;
import android.graphics.Bitmap;
import android.graphics.RectF;
import android.os.SystemClock;
import android.os.Trace;
import android.util.Log;
import com.google.mediapipe.framework.image.BitmapImageBuilder;
import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.components.containers.Category;
import com.google.mediapipe.tasks.core.BaseOptions;
import com.google.mediapipe.tasks.core.Delegate;
import com.google.mediapipe.tasks.vision.core.ImageProcessingOptions;
import com.google.mediapipe.tasks.vision.imageclassifier.ImageClassifier;
import com.google.mediapipe.tasks.vision.imageclassifier.ImageClassifierResult;
import java.util.ArrayList;

/* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.e, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0087e {
    public final ImageClassifier a;

    public AbstractC0087e(Activity activity) {
        BaseOptions.Builder modelAssetPath = BaseOptions.builder().setModelAssetPath("efficientnet-lite0-blur-v1.3.tflite");
        int iA = AbstractC0085c.a(1);
        modelAssetPath.setDelegate((iA == 1 || iA != 2) ? Delegate.CPU : Delegate.GPU);
        this.a = ImageClassifier.createFromOptions(activity, ImageClassifier.ImageClassifierOptions.builder().setBaseOptions(modelAssetPath.build()).setMaxResults(3).build());
        Log.d("MediaPipeBlurClassifier", "Created MediaPipe Image Classifier successfully");
    }

    public final ArrayList a(Bitmap bitmap, int i) {
        Trace.beginSection("recognizeImage");
        MPImage mPImageBuild = new BitmapImageBuilder(bitmap).build();
        int width = bitmap.getWidth();
        int height = bitmap.getHeight();
        int iMin = Math.min(width, height);
        float f = width;
        float f2 = height;
        ImageProcessingOptions imageProcessingOptionsBuild = ImageProcessingOptions.builder().setRotationDegrees(i).setRegionOfInterest(new RectF(((width - iMin) / 2.0f) / f, ((height - iMin) / 2.0f) / f2, ((width + iMin) / 2.0f) / f, ((height + iMin) / 2.0f) / f2)).build();
        Trace.beginSection("runInference");
        long jUptimeMillis = SystemClock.uptimeMillis();
        ImageClassifierResult imageClassifierResultClassify = this.a.classify(mPImageBuild, imageProcessingOptionsBuild);
        long jUptimeMillis2 = SystemClock.uptimeMillis();
        Trace.endSection();
        Log.d("MediaPipeBlurClassifier", "Inference completed in: " + (jUptimeMillis2 - jUptimeMillis) + "ms");
        Trace.endSection();
        ArrayList arrayList = new ArrayList();
        if (imageClassifierResultClassify.classificationResult().classifications().size() > 0) {
            for (Category category : imageClassifierResultClassify.classificationResult().classifications().get(0).categories()) {
                arrayList.add(new C0086d("" + category.index(), category.categoryName(), Float.valueOf(category.score())));
            }
        }
        return arrayList;
    }
}
