package com.google.common.flogger.backend;

import java.math.BigDecimal;
import java.math.BigInteger;

/* JADX INFO: loaded from: classes2.dex */
public enum FormatType {
    GENERAL(0 == true ? 1 : 0, true) { // from class: com.google.common.flogger.backend.FormatType.1
        @Override // com.google.common.flogger.backend.FormatType
        public boolean canFormat(Object obj) {
            return true;
        }
    },
    BOOLEAN(0 == true ? 1 : 0, 0 == true ? 1 : 0) { // from class: com.google.common.flogger.backend.FormatType.2
        @Override // com.google.common.flogger.backend.FormatType
        public boolean canFormat(Object obj) {
            return obj instanceof Boolean;
        }
    },
    CHARACTER(0 == true ? 1 : 0, 0 == true ? 1 : 0) { // from class: com.google.common.flogger.backend.FormatType.3
        @Override // com.google.common.flogger.backend.FormatType
        public boolean canFormat(Object obj) {
            if (obj instanceof Character) {
                return true;
            }
            if ((obj instanceof Integer) || (obj instanceof Byte) || (obj instanceof Short)) {
                return Character.isValidCodePoint(((Number) obj).intValue());
            }
            return false;
        }
    },
    INTEGRAL(1 == true ? 1 : 0, 0 == true ? 1 : 0) { // from class: com.google.common.flogger.backend.FormatType.4
        @Override // com.google.common.flogger.backend.FormatType
        public boolean canFormat(Object obj) {
            return (obj instanceof Integer) || (obj instanceof Long) || (obj instanceof Byte) || (obj instanceof Short) || (obj instanceof BigInteger);
        }
    },
    FLOAT(1 == true ? 1 : 0, 1 == true ? 1 : 0) { // from class: com.google.common.flogger.backend.FormatType.5
        @Override // com.google.common.flogger.backend.FormatType
        public boolean canFormat(Object obj) {
            return (obj instanceof Double) || (obj instanceof Float) || (obj instanceof BigDecimal);
        }
    };

    private final boolean isNumeric;
    private final boolean supportsPrecision;

    public abstract boolean canFormat(Object obj);

    FormatType(boolean z, boolean z2) {
        this.isNumeric = z;
        this.supportsPrecision = z2;
    }

    boolean supportsPrecision() {
        return this.supportsPrecision;
    }

    public boolean isNumeric() {
        return this.isNumeric;
    }
}
