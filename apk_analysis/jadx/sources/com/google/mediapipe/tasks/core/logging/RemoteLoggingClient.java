package com.google.mediapipe.tasks.core.logging;

import android.content.Context;
import com.google.android.datatransport.Encoding;
import com.google.android.datatransport.Event;
import com.google.android.datatransport.Transformer;
import com.google.android.datatransport.Transport;
import com.google.android.datatransport.cct.CCTDestination;
import com.google.android.datatransport.runtime.TransportRuntime;
import com.google.mediapipe.proto.MediaPipeLoggingProto;

/* JADX INFO: loaded from: classes3.dex */
public class RemoteLoggingClient implements LoggingClient {
    private static final String LOG_SOURCE = "COREML_ON_DEVICE_SOLUTIONS";
    private static final String TAG = "RemoteLoggingClient";
    private final Transport<MediaPipeLoggingProto.MediaPipeLogExtension> transport;

    public RemoteLoggingClient(Context context) {
        TransportRuntime.initialize(context.getApplicationContext());
        this.transport = TransportRuntime.getInstance().newFactory(CCTDestination.INSTANCE).getTransport(LOG_SOURCE, MediaPipeLoggingProto.MediaPipeLogExtension.class, Encoding.of("proto"), new Transformer() { // from class: com.google.mediapipe.tasks.core.logging.RemoteLoggingClient$$ExternalSyntheticLambda0
            @Override // com.google.android.datatransport.Transformer
            public final Object apply(Object obj) {
                return ((MediaPipeLoggingProto.MediaPipeLogExtension) obj).toByteArray();
            }
        });
    }

    @Override // com.google.mediapipe.tasks.core.logging.LoggingClient
    public void logEvent(MediaPipeLoggingProto.MediaPipeLogExtension mediaPipeLogExtension) {
        this.transport.send(Event.ofData(mediaPipeLogExtension));
    }
}
