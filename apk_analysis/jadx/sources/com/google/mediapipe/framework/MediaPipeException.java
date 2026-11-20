package com.google.mediapipe.framework;

import io.appmetrica.analytics.coreutils.internal.services.telephony.CellularNetworkTypeExtractor;
import java.nio.charset.StandardCharsets;

/* JADX INFO: loaded from: classes3.dex */
public class MediaPipeException extends RuntimeException {
    private final StatusCode statusCode;
    private final String statusMessage;

    public MediaPipeException(int i, String str) {
        super(StatusCode.values()[i].description() + ": " + str);
        this.statusCode = StatusCode.values()[i];
        this.statusMessage = str;
    }

    MediaPipeException(int i, byte[] bArr) {
        this(i, new String(bArr, StandardCharsets.UTF_8));
    }

    public StatusCode getStatusCode() {
        return this.statusCode;
    }

    public String getStatusMessage() {
        return this.statusMessage;
    }

    public enum StatusCode {
        OK("ok"),
        CANCELLED("canceled"),
        UNKNOWN(CellularNetworkTypeExtractor.UNKNOWN_NETWORK_TYPE_VALUE),
        INVALID_ARGUMENT("invalid argument"),
        DEADLINE_EXCEEDED("deadline exceeded"),
        NOT_FOUND("not found"),
        ALREADY_EXISTS("already exists"),
        PERMISSION_DENIED("permission denied"),
        RESOURCE_EXHAUSTED("resource exhausted"),
        FAILED_PRECONDITION("failed precondition"),
        ABORTED("aborted"),
        OUT_OF_RANGE("out of range"),
        UNIMPLEMENTED("unimplemented"),
        INTERNAL("internal"),
        UNAVAILABLE("unavailable"),
        DATA_LOSS("data loss"),
        UNAUTHENTICATED("unauthenticated"),
        IO_EXCEPTION("i/o exception");

        private final String description;

        StatusCode(String str) {
            this.description = str;
        }

        public String description() {
            return this.description;
        }
    }
}
