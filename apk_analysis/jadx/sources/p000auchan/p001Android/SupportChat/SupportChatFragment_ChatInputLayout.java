package p000auchan.p001Android.SupportChat;

import android.content.Context;
import android.util.AttributeSet;
import com.google.android.material.textfield.TextInputLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class SupportChatFragment_ChatInputLayout extends TextInputLayout implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.SupportChat.ChatFragment+ChatInputLayout, Auchan.Android.Net", SupportChatFragment_ChatInputLayout.class, "");
    }

    public SupportChatFragment_ChatInputLayout(Context context) {
        super(context);
        if (getClass() == SupportChatFragment_ChatInputLayout.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.ChatFragment+ChatInputLayout, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public SupportChatFragment_ChatInputLayout(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == SupportChatFragment_ChatInputLayout.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.ChatFragment+ChatInputLayout, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public SupportChatFragment_ChatInputLayout(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == SupportChatFragment_ChatInputLayout.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.ChatFragment+ChatInputLayout, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
