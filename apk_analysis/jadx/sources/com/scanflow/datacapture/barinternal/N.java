package com.scanflow.datacapture.barinternal;

import android.content.Context;
import android.graphics.Bitmap;
import android.os.Trace;
import com.google.mediapipe.framework.image.BitmapImageBuilder;
import com.google.mediapipe.tasks.components.containers.Category;
import com.google.mediapipe.tasks.components.containers.Detection;
import com.google.mediapipe.tasks.core.BaseOptions;
import com.google.mediapipe.tasks.core.Delegate;
import com.google.mediapipe.tasks.vision.core.RunningMode;
import com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector;
import java.io.File;
import java.io.FileInputStream;
import java.nio.channels.FileChannel;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class N {
    public final File a;
    public ObjectDetector b;
    public final Context c;

    public N(Context context, File file) {
        this.c = context;
        this.a = file;
        a();
    }

    public final ArrayList a(Bitmap bitmap) {
        Trace.beginSection("recognizeImage");
        ArrayList arrayList = new ArrayList();
        if (this.b == null) {
            return arrayList;
        }
        try {
            int i = 0;
            for (Detection detection : this.b.detect(new BitmapImageBuilder(bitmap).build()).detections()) {
                List<Category> listCategories = detection.categories();
                if (listCategories != null && !listCategories.isEmpty()) {
                    StringBuilder sb = new StringBuilder();
                    sb.append("");
                    int i2 = i + 1;
                    sb.append(i);
                    arrayList.add(new C0084b(sb.toString(), listCategories.get(0).categoryName(), listCategories.get(0).score(), detection.boundingBox()));
                    i = i2;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        Trace.endSection();
        return arrayList;
    }

    public final void a() {
        ObjectDetector objectDetector = this.b;
        if (objectDetector != null) {
            objectDetector.close();
            this.b = null;
        }
        try {
            FileChannel channel = new FileInputStream(this.a).getChannel();
            BaseOptions.Builder modelAssetBuffer = BaseOptions.builder().setModelAssetBuffer(channel.map(FileChannel.MapMode.READ_ONLY, 0L, channel.size()));
            modelAssetBuffer.setDelegate(Delegate.CPU);
            this.b = ObjectDetector.createFromOptions(this.c, ObjectDetector.ObjectDetectorOptions.builder().setBaseOptions(modelAssetBuffer.build()).setRunningMode(RunningMode.IMAGE).setMaxResults(45).setScoreThreshold(Float.valueOf(0.2f)).build());
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
