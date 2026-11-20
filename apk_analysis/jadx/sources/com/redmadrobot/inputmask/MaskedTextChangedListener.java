package com.redmadrobot.inputmask;

import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.EditText;
import com.redmadrobot.inputmask.helper.AffinityCalculationStrategy;
import com.redmadrobot.inputmask.helper.Mask;
import com.redmadrobot.inputmask.helper.RTLMask;
import com.redmadrobot.inputmask.model.CaretString;
import com.redmadrobot.inputmask.model.Notation;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.comparisons.ComparisonsKt;
import java.lang.ref.WeakReference;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.Iterator;
import java.util.List;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: MaskedTextChangedListener.kt */
/* JADX INFO: loaded from: classes3.dex */
public class MaskedTextChangedListener implements TextWatcher, View.OnFocusChangeListener {
    public static final Companion Companion = new Companion(null);
    private List<String> affineFormats;
    private AffinityCalculationStrategy affinityCalculationStrategy;
    private String afterText;
    private boolean autocomplete;
    private boolean autoskip;
    private int caretPosition;
    private List<Notation> customNotations;
    private final WeakReference<EditText> field;
    private TextWatcher listener;
    private String primaryFormat;
    private boolean rightToLeft;
    private ValueListener valueListener;

    /* JADX INFO: compiled from: MaskedTextChangedListener.kt */
    public interface ValueListener {
        void onTextChanged(boolean z, String str, String str2);
    }

    public MaskedTextChangedListener(String primaryFormat, List<String> affineFormats, List<Notation> customNotations, AffinityCalculationStrategy affinityCalculationStrategy, boolean z, boolean z2, EditText field, TextWatcher textWatcher, ValueListener valueListener, boolean z3) {
        Intrinsics.checkParameterIsNotNull(primaryFormat, "primaryFormat");
        Intrinsics.checkParameterIsNotNull(affineFormats, "affineFormats");
        Intrinsics.checkParameterIsNotNull(customNotations, "customNotations");
        Intrinsics.checkParameterIsNotNull(affinityCalculationStrategy, "affinityCalculationStrategy");
        Intrinsics.checkParameterIsNotNull(field, "field");
        this.primaryFormat = primaryFormat;
        this.affineFormats = affineFormats;
        this.customNotations = customNotations;
        this.affinityCalculationStrategy = affinityCalculationStrategy;
        this.autocomplete = z;
        this.autoskip = z2;
        this.listener = textWatcher;
        this.valueListener = valueListener;
        this.rightToLeft = z3;
        this.afterText = "";
        this.field = new WeakReference<>(field);
    }

    public final String getPrimaryFormat() {
        return this.primaryFormat;
    }

    public final void setPrimaryFormat(String str) {
        Intrinsics.checkParameterIsNotNull(str, "<set-?>");
        this.primaryFormat = str;
    }

    public /* synthetic */ MaskedTextChangedListener(String str, List list, List list2, AffinityCalculationStrategy affinityCalculationStrategy, boolean z, boolean z2, EditText editText, TextWatcher textWatcher, ValueListener valueListener, boolean z3, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this(str, (i & 2) != 0 ? CollectionsKt.emptyList() : list, (i & 4) != 0 ? CollectionsKt.emptyList() : list2, (i & 8) != 0 ? AffinityCalculationStrategy.WHOLE_STRING : affinityCalculationStrategy, (i & 16) != 0 ? true : z, (i & 32) != 0 ? false : z2, editText, (i & 128) != 0 ? null : textWatcher, (i & 256) != 0 ? null : valueListener, (i & 512) != 0 ? false : z3);
    }

    public final List<String> getAffineFormats() {
        return this.affineFormats;
    }

    public final void setAffineFormats(List<String> list) {
        Intrinsics.checkParameterIsNotNull(list, "<set-?>");
        this.affineFormats = list;
    }

    public final List<Notation> getCustomNotations() {
        return this.customNotations;
    }

    public final void setCustomNotations(List<Notation> list) {
        Intrinsics.checkParameterIsNotNull(list, "<set-?>");
        this.customNotations = list;
    }

    public final AffinityCalculationStrategy getAffinityCalculationStrategy() {
        return this.affinityCalculationStrategy;
    }

    public final void setAffinityCalculationStrategy(AffinityCalculationStrategy affinityCalculationStrategy) {
        Intrinsics.checkParameterIsNotNull(affinityCalculationStrategy, "<set-?>");
        this.affinityCalculationStrategy = affinityCalculationStrategy;
    }

    public final boolean getAutocomplete() {
        return this.autocomplete;
    }

    public final void setAutocomplete(boolean z) {
        this.autocomplete = z;
    }

    public final boolean getAutoskip() {
        return this.autoskip;
    }

    public final void setAutoskip(boolean z) {
        this.autoskip = z;
    }

    public final TextWatcher getListener() {
        return this.listener;
    }

    public final void setListener(TextWatcher textWatcher) {
        this.listener = textWatcher;
    }

    public final ValueListener getValueListener() {
        return this.valueListener;
    }

    public final void setValueListener(ValueListener valueListener) {
        this.valueListener = valueListener;
    }

    public final boolean getRightToLeft() {
        return this.rightToLeft;
    }

    public final void setRightToLeft(boolean z) {
        this.rightToLeft = z;
    }

    private final Mask getPrimaryMask() {
        return maskGetOrCreate(this.primaryFormat, this.customNotations);
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public MaskedTextChangedListener(String format, EditText field) {
        this(format, field, (ValueListener) null);
        Intrinsics.checkParameterIsNotNull(format, "format");
        Intrinsics.checkParameterIsNotNull(field, "field");
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public MaskedTextChangedListener(String format, EditText field, ValueListener valueListener) {
        this(format, field, (TextWatcher) null, valueListener);
        Intrinsics.checkParameterIsNotNull(format, "format");
        Intrinsics.checkParameterIsNotNull(field, "field");
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public MaskedTextChangedListener(String format, EditText field, TextWatcher textWatcher, ValueListener valueListener) {
        this(format, true, field, textWatcher, valueListener);
        Intrinsics.checkParameterIsNotNull(format, "format");
        Intrinsics.checkParameterIsNotNull(field, "field");
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public MaskedTextChangedListener(String format, boolean z, EditText field, TextWatcher textWatcher, ValueListener valueListener) {
        this(format, CollectionsKt.emptyList(), CollectionsKt.emptyList(), AffinityCalculationStrategy.WHOLE_STRING, z, false, field, textWatcher, valueListener, false, 512, null);
        Intrinsics.checkParameterIsNotNull(format, "format");
        Intrinsics.checkParameterIsNotNull(field, "field");
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public MaskedTextChangedListener(String primaryFormat, List<String> affineFormats, EditText field) {
        this(primaryFormat, affineFormats, field, (ValueListener) null);
        Intrinsics.checkParameterIsNotNull(primaryFormat, "primaryFormat");
        Intrinsics.checkParameterIsNotNull(affineFormats, "affineFormats");
        Intrinsics.checkParameterIsNotNull(field, "field");
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public MaskedTextChangedListener(String primaryFormat, List<String> affineFormats, EditText field, ValueListener valueListener) {
        this(primaryFormat, affineFormats, field, (TextWatcher) null, valueListener);
        Intrinsics.checkParameterIsNotNull(primaryFormat, "primaryFormat");
        Intrinsics.checkParameterIsNotNull(affineFormats, "affineFormats");
        Intrinsics.checkParameterIsNotNull(field, "field");
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public MaskedTextChangedListener(String primaryFormat, List<String> affineFormats, EditText field, TextWatcher textWatcher, ValueListener valueListener) {
        this(primaryFormat, affineFormats, true, field, textWatcher, valueListener);
        Intrinsics.checkParameterIsNotNull(primaryFormat, "primaryFormat");
        Intrinsics.checkParameterIsNotNull(affineFormats, "affineFormats");
        Intrinsics.checkParameterIsNotNull(field, "field");
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public MaskedTextChangedListener(String primaryFormat, List<String> affineFormats, boolean z, EditText field, TextWatcher textWatcher, ValueListener valueListener) {
        this(primaryFormat, affineFormats, AffinityCalculationStrategy.WHOLE_STRING, z, field, textWatcher, valueListener);
        Intrinsics.checkParameterIsNotNull(primaryFormat, "primaryFormat");
        Intrinsics.checkParameterIsNotNull(affineFormats, "affineFormats");
        Intrinsics.checkParameterIsNotNull(field, "field");
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public MaskedTextChangedListener(String primaryFormat, List<String> affineFormats, AffinityCalculationStrategy affinityCalculationStrategy, boolean z, EditText field, TextWatcher textWatcher, ValueListener valueListener) {
        this(primaryFormat, affineFormats, CollectionsKt.emptyList(), affinityCalculationStrategy, z, false, field, textWatcher, valueListener, false, 512, null);
        Intrinsics.checkParameterIsNotNull(primaryFormat, "primaryFormat");
        Intrinsics.checkParameterIsNotNull(affineFormats, "affineFormats");
        Intrinsics.checkParameterIsNotNull(affinityCalculationStrategy, "affinityCalculationStrategy");
        Intrinsics.checkParameterIsNotNull(field, "field");
    }

    public static /* synthetic */ Mask.Result setText$default(MaskedTextChangedListener maskedTextChangedListener, String str, Boolean bool, int i, Object obj) {
        if (obj != null) {
            throw new UnsupportedOperationException("Super calls with default arguments not supported in this target, function: setText");
        }
        if ((i & 2) != 0) {
            bool = null;
        }
        return maskedTextChangedListener.setText(str, bool);
    }

    public Mask.Result setText(String text, Boolean bool) {
        Intrinsics.checkParameterIsNotNull(text, "text");
        EditText it = this.field.get();
        if (it == null) {
            return null;
        }
        Intrinsics.checkExpressionValueIsNotNull(it, "it");
        Mask.Result text2 = setText(text, it, bool);
        this.afterText = text2.getFormattedText().getString();
        this.caretPosition = text2.getFormattedText().getCaretPosition();
        ValueListener valueListener = this.valueListener;
        if (valueListener != null) {
            valueListener.onTextChanged(text2.getComplete(), text2.getExtractedValue(), this.afterText);
        }
        return text2;
    }

    public static /* synthetic */ Mask.Result setText$default(MaskedTextChangedListener maskedTextChangedListener, String str, EditText editText, Boolean bool, int i, Object obj) {
        if (obj != null) {
            throw new UnsupportedOperationException("Super calls with default arguments not supported in this target, function: setText");
        }
        if ((i & 4) != 0) {
            bool = null;
        }
        return maskedTextChangedListener.setText(str, editText, bool);
    }

    public Mask.Result setText(String text, EditText field, Boolean bool) {
        Intrinsics.checkParameterIsNotNull(text, "text");
        Intrinsics.checkParameterIsNotNull(field, "field");
        CaretString caretString = new CaretString(text, text.length(), new CaretString.CaretGravity.FORWARD(bool != null ? bool.booleanValue() : this.autocomplete));
        Mask.Result resultApply = pickMask(caretString).apply(caretString);
        field.setText(resultApply.getFormattedText().getString());
        field.setSelection(resultApply.getFormattedText().getCaretPosition());
        return resultApply;
    }

    public final String placeholder() {
        return getPrimaryMask().placeholder();
    }

    public final int acceptableTextLength() {
        return getPrimaryMask().acceptableTextLength();
    }

    public final int totalTextLength() {
        return getPrimaryMask().totalTextLength();
    }

    public final int acceptableValueLength() {
        return getPrimaryMask().acceptableValueLength();
    }

    public final int totalValueLength() {
        return getPrimaryMask().totalValueLength();
    }

    @Override // android.text.TextWatcher
    public void afterTextChanged(Editable editable) {
        EditText editText = this.field.get();
        if (editText != null) {
            editText.removeTextChangedListener(this);
        }
        if (editable != null) {
            editable.replace(0, editable.length(), this.afterText);
        }
        EditText editText2 = this.field.get();
        if (editText2 != null) {
            editText2.setSelection(this.caretPosition);
        }
        EditText editText3 = this.field.get();
        if (editText3 != null) {
            editText3.addTextChangedListener(this);
        }
        TextWatcher textWatcher = this.listener;
        if (textWatcher != null) {
            textWatcher.afterTextChanged(editable);
        }
    }

    @Override // android.text.TextWatcher
    public void beforeTextChanged(CharSequence charSequence, int i, int i2, int i3) {
        TextWatcher textWatcher = this.listener;
        if (textWatcher != null) {
            textWatcher.beforeTextChanged(charSequence, i, i2, i3);
        }
    }

    @Override // android.text.TextWatcher
    public void onTextChanged(CharSequence text, int i, int i2, int i3) {
        Intrinsics.checkParameterIsNotNull(text, "text");
        boolean z = i2 > 0 && i3 == 0;
        CaretString.CaretGravity backward = z ? new CaretString.CaretGravity.BACKWARD(z ? this.autoskip : false) : new CaretString.CaretGravity.FORWARD(z ? false : this.autocomplete);
        if (!z) {
            i += i3;
        }
        CaretString caretString = new CaretString(text.toString(), i, backward);
        Mask.Result resultApply = pickMask(caretString).apply(caretString);
        this.afterText = resultApply.getFormattedText().getString();
        this.caretPosition = resultApply.getFormattedText().getCaretPosition();
        ValueListener valueListener = this.valueListener;
        if (valueListener != null) {
            valueListener.onTextChanged(resultApply.getComplete(), resultApply.getExtractedValue(), this.afterText);
        }
    }

    @Override // android.view.View.OnFocusChangeListener
    public void onFocusChange(View view, boolean z) {
        String strValueOf;
        if (this.autocomplete && z) {
            EditText editText = this.field.get();
            Editable text = editText != null ? editText.getText() : null;
            if (text == null) {
                Intrinsics.throwNpe();
            }
            if (text.length() == 0) {
                strValueOf = "";
            } else {
                EditText editText2 = this.field.get();
                strValueOf = String.valueOf(editText2 != null ? editText2.getText() : null);
            }
            CaretString caretString = new CaretString(strValueOf, strValueOf.length(), new CaretString.CaretGravity.FORWARD(this.autocomplete));
            Mask.Result resultApply = pickMask(caretString).apply(caretString);
            this.afterText = resultApply.getFormattedText().getString();
            this.caretPosition = resultApply.getFormattedText().getCaretPosition();
            EditText editText3 = this.field.get();
            if (editText3 != null) {
                editText3.setText(this.afterText);
            }
            EditText editText4 = this.field.get();
            if (editText4 != null) {
                editText4.setSelection(resultApply.getFormattedText().getCaretPosition());
            }
            ValueListener valueListener = this.valueListener;
            if (valueListener != null) {
                valueListener.onTextChanged(resultApply.getComplete(), resultApply.getExtractedValue(), this.afterText);
            }
        }
    }

    private final Mask pickMask(CaretString caretString) {
        if (this.affineFormats.isEmpty()) {
            return getPrimaryMask();
        }
        int iCalculateAffinity = calculateAffinity(getPrimaryMask(), caretString);
        ArrayList arrayList = new ArrayList();
        Iterator<String> it = this.affineFormats.iterator();
        while (it.hasNext()) {
            Mask maskMaskGetOrCreate = maskGetOrCreate(it.next(), this.customNotations);
            arrayList.add(new MaskAffinity(maskMaskGetOrCreate, calculateAffinity(maskMaskGetOrCreate, caretString)));
        }
        if (arrayList.size() > 1) {
            CollectionsKt.sortWith(arrayList, new Comparator<T>() { // from class: com.redmadrobot.inputmask.MaskedTextChangedListener$pickMask$$inlined$sortByDescending$1
                /* JADX WARN: Multi-variable type inference failed */
                @Override // java.util.Comparator
                public final int compare(T t, T t2) {
                    return ComparisonsKt.compareValues(Integer.valueOf(((MaskedTextChangedListener.MaskAffinity) t2).getAffinity()), Integer.valueOf(((MaskedTextChangedListener.MaskAffinity) t).getAffinity()));
                }
            });
        }
        int size = arrayList.size();
        int i = 0;
        int i2 = 0;
        while (true) {
            if (i2 >= size) {
                i = -1;
                break;
            }
            Object obj = arrayList.get(i2);
            i2++;
            if (iCalculateAffinity >= ((MaskAffinity) obj).getAffinity()) {
                break;
            }
            i++;
        }
        if (i >= 0) {
            arrayList.add(i, new MaskAffinity(getPrimaryMask(), iCalculateAffinity));
        } else {
            arrayList.add(new MaskAffinity(getPrimaryMask(), iCalculateAffinity));
        }
        return ((MaskAffinity) CollectionsKt.first((List) arrayList)).getMask();
    }

    /* JADX INFO: compiled from: MaskedTextChangedListener.kt */
    public static final class MaskAffinity {
        private final int affinity;
        private final Mask mask;

        public static /* synthetic */ MaskAffinity copy$default(MaskAffinity maskAffinity, Mask mask, int i, int i2, Object obj) {
            if ((i2 & 1) != 0) {
                mask = maskAffinity.mask;
            }
            if ((i2 & 2) != 0) {
                i = maskAffinity.affinity;
            }
            return maskAffinity.copy(mask, i);
        }

        public final Mask component1() {
            return this.mask;
        }

        public final int component2() {
            return this.affinity;
        }

        public final MaskAffinity copy(Mask mask, int i) {
            Intrinsics.checkParameterIsNotNull(mask, "mask");
            return new MaskAffinity(mask, i);
        }

        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (!(obj instanceof MaskAffinity)) {
                return false;
            }
            MaskAffinity maskAffinity = (MaskAffinity) obj;
            return Intrinsics.areEqual(this.mask, maskAffinity.mask) && this.affinity == maskAffinity.affinity;
        }

        public int hashCode() {
            Mask mask = this.mask;
            return ((mask != null ? mask.hashCode() : 0) * 31) + this.affinity;
        }

        public String toString() {
            return "MaskAffinity(mask=" + this.mask + ", affinity=" + this.affinity + ")";
        }

        public MaskAffinity(Mask mask, int i) {
            Intrinsics.checkParameterIsNotNull(mask, "mask");
            this.mask = mask;
            this.affinity = i;
        }

        public final int getAffinity() {
            return this.affinity;
        }

        public final Mask getMask() {
            return this.mask;
        }
    }

    private final Mask maskGetOrCreate(String str, List<Notation> list) {
        if (this.rightToLeft) {
            return RTLMask.Factory.getOrCreate(str, list);
        }
        return Mask.Factory.getOrCreate(str, list);
    }

    private final int calculateAffinity(Mask mask, CaretString caretString) {
        return this.affinityCalculationStrategy.calculateAffinityOfMask(mask, caretString);
    }

    /* JADX INFO: compiled from: MaskedTextChangedListener.kt */
    public static final class Companion {
        private Companion() {
        }

        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        public static /* synthetic */ MaskedTextChangedListener installOn$default(Companion companion, EditText editText, String str, ValueListener valueListener, int i, Object obj) {
            if ((i & 4) != 0) {
                valueListener = null;
            }
            return companion.installOn(editText, str, valueListener);
        }

        public final MaskedTextChangedListener installOn(EditText editText, String primaryFormat, ValueListener valueListener) {
            Intrinsics.checkParameterIsNotNull(editText, "editText");
            Intrinsics.checkParameterIsNotNull(primaryFormat, "primaryFormat");
            return installOn(editText, primaryFormat, CollectionsKt.emptyList(), AffinityCalculationStrategy.WHOLE_STRING, valueListener);
        }

        /* JADX WARN: Multi-variable type inference failed */
        public static /* synthetic */ MaskedTextChangedListener installOn$default(Companion companion, EditText editText, String str, List list, AffinityCalculationStrategy affinityCalculationStrategy, ValueListener valueListener, int i, Object obj) {
            if ((i & 4) != 0) {
                list = CollectionsKt.emptyList();
            }
            List list2 = list;
            if ((i & 8) != 0) {
                affinityCalculationStrategy = AffinityCalculationStrategy.WHOLE_STRING;
            }
            AffinityCalculationStrategy affinityCalculationStrategy2 = affinityCalculationStrategy;
            if ((i & 16) != 0) {
                valueListener = null;
            }
            return companion.installOn(editText, str, list2, affinityCalculationStrategy2, valueListener);
        }

        public final MaskedTextChangedListener installOn(EditText editText, String primaryFormat, List<String> affineFormats, AffinityCalculationStrategy affinityCalculationStrategy, ValueListener valueListener) {
            Intrinsics.checkParameterIsNotNull(editText, "editText");
            Intrinsics.checkParameterIsNotNull(primaryFormat, "primaryFormat");
            Intrinsics.checkParameterIsNotNull(affineFormats, "affineFormats");
            Intrinsics.checkParameterIsNotNull(affinityCalculationStrategy, "affinityCalculationStrategy");
            return installOn(editText, primaryFormat, affineFormats, CollectionsKt.emptyList(), affinityCalculationStrategy, true, false, null, valueListener);
        }

        /* JADX WARN: Multi-variable type inference failed */
        public static /* synthetic */ MaskedTextChangedListener installOn$default(Companion companion, EditText editText, String str, List list, List list2, AffinityCalculationStrategy affinityCalculationStrategy, boolean z, boolean z2, TextWatcher textWatcher, ValueListener valueListener, int i, Object obj) {
            if ((i & 4) != 0) {
                list = CollectionsKt.emptyList();
            }
            return companion.installOn(editText, str, list, (i & 8) != 0 ? CollectionsKt.emptyList() : list2, (i & 16) != 0 ? AffinityCalculationStrategy.WHOLE_STRING : affinityCalculationStrategy, (i & 32) != 0 ? true : z, (i & 64) != 0 ? false : z2, (i & 128) != 0 ? null : textWatcher, (i & 256) != 0 ? null : valueListener);
        }

        public final MaskedTextChangedListener installOn(EditText editText, String primaryFormat, List<String> affineFormats, List<Notation> customNotations, AffinityCalculationStrategy affinityCalculationStrategy, boolean z, boolean z2, TextWatcher textWatcher, ValueListener valueListener) {
            Intrinsics.checkParameterIsNotNull(editText, "editText");
            Intrinsics.checkParameterIsNotNull(primaryFormat, "primaryFormat");
            Intrinsics.checkParameterIsNotNull(affineFormats, "affineFormats");
            Intrinsics.checkParameterIsNotNull(customNotations, "customNotations");
            Intrinsics.checkParameterIsNotNull(affinityCalculationStrategy, "affinityCalculationStrategy");
            MaskedTextChangedListener maskedTextChangedListener = new MaskedTextChangedListener(primaryFormat, affineFormats, customNotations, affinityCalculationStrategy, z, z2, editText, textWatcher, valueListener, false, 512, null);
            editText.addTextChangedListener(maskedTextChangedListener);
            editText.setOnFocusChangeListener(maskedTextChangedListener);
            return maskedTextChangedListener;
        }
    }
}
