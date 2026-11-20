package com.google.common.flogger.backend;

import com.google.common.flogger.MetadataKey;

/* JADX INFO: loaded from: classes2.dex */
public abstract class Metadata {
    public abstract <T> T findValue(MetadataKey<T> metadataKey);

    public abstract MetadataKey<?> getKey(int i);

    public abstract Object getValue(int i);

    public abstract int size();

    public static Metadata empty() {
        return Empty.INSTANCE;
    }

    private static final class Empty extends Metadata {
        static final Empty INSTANCE = new Empty();

        @Override // com.google.common.flogger.backend.Metadata
        public <T> T findValue(MetadataKey<T> metadataKey) {
            return null;
        }

        @Override // com.google.common.flogger.backend.Metadata
        public int size() {
            return 0;
        }

        private Empty() {
        }

        @Override // com.google.common.flogger.backend.Metadata
        public MetadataKey<?> getKey(int i) {
            throw new IndexOutOfBoundsException("cannot read from empty metadata");
        }

        @Override // com.google.common.flogger.backend.Metadata
        public Object getValue(int i) {
            throw new IndexOutOfBoundsException("cannot read from empty metadata");
        }
    }
}
