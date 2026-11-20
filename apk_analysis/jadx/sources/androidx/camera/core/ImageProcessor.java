package androidx.camera.core;

/* JADX INFO: loaded from: classes.dex */
public interface ImageProcessor {

    public interface Request {
        ImageProxy getInputImage();

        int getOutputFormat();
    }

    public interface Response {
        ImageProxy getOutputImage();
    }

    Response process(Request request);
}
