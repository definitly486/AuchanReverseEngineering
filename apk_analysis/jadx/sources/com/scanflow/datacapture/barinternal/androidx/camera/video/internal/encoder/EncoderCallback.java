package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder;

/* JADX INFO: loaded from: classes.dex */
public interface EncoderCallback {
    public static final EncoderCallback EMPTY = new EncoderCallback() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncoderCallback.1
        @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncoderCallback
        public void onEncodeStart() {
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncoderCallback
        public void onEncodeStop() {
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncoderCallback
        public void onEncodeError(EncodeException encodeException) {
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncoderCallback
        public void onEncodedData(EncodedData encodedData) {
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncoderCallback
        public void onOutputConfigUpdate(OutputConfig outputConfig) {
        }
    };

    void onEncodeError(EncodeException encodeException);

    void onEncodeStart();

    void onEncodeStop();

    void onEncodedData(EncodedData encodedData);

    void onOutputConfigUpdate(OutputConfig outputConfig);

    default void onEncodePaused() {
    }
}
