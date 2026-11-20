package io.appmetrica.analytics.coreapi.internal.data;

import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;

/* JADX INFO: loaded from: classes3.dex */
public interface Parser<IN, OUT> {

    public static final class DefaultImpls {
        /* JADX WARN: Multi-variable type inference failed */
        public static <IN, OUT> OUT parseOrNull(Parser<? super IN, ? extends OUT> parser, IN in) {
            OUT out;
            try {
                Result.Companion companion = Result.Companion;
                out = (OUT) Result.m681constructorimpl(parser.parse(in));
            } catch (Throwable th) {
                Result.Companion companion2 = Result.Companion;
                out = (OUT) Result.m681constructorimpl(ResultKt.createFailure(th));
            }
            if (Result.m685isFailureimpl(out)) {
                return null;
            }
            return out;
        }
    }

    OUT parse(IN in);

    OUT parseOrNull(IN in);
}
