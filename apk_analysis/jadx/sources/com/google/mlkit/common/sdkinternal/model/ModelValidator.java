package com.google.mlkit.common.sdkinternal.model;

import com.google.android.gms.common.annotation.KeepForSdk;
import com.google.mlkit.common.model.RemoteModel;
import java.io.File;

/* JADX INFO: compiled from: com.google.mlkit:common@@18.11.0 */
/* JADX INFO: loaded from: classes3.dex */
@KeepForSdk
public interface ModelValidator {

    /* JADX INFO: compiled from: com.google.mlkit:common@@18.11.0 */
    @KeepForSdk
    public static class ValidationResult {

        @KeepForSdk
        public static final ValidationResult VALID = new ValidationResult(ErrorCode.OK, null);
        private final ErrorCode zza;
        private final String zzb;

        /* JADX INFO: compiled from: com.google.mlkit:common@@18.11.0 */
        @KeepForSdk
        public enum ErrorCode {
            OK,
            TFLITE_VERSION_INCOMPATIBLE,
            MODEL_FORMAT_INVALID
        }

        @KeepForSdk
        public ValidationResult(ErrorCode errorCode, String str) {
            this.zza = errorCode;
            this.zzb = str;
        }

        @KeepForSdk
        public ErrorCode getErrorCode() {
            return this.zza;
        }

        @KeepForSdk
        public String getErrorMessage() {
            return this.zzb;
        }

        @KeepForSdk
        public boolean isValid() {
            return this.zza == ErrorCode.OK;
        }
    }

    @KeepForSdk
    ValidationResult validateModel(File file, RemoteModel remoteModel);
}
