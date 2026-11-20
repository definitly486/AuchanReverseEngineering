package androidx.constraintlayout.motion.widget;

import android.content.Context;
import android.util.Log;
import android.util.Xml;
import androidx.constraintlayout.widget.ConstraintAttribute;
import androidx.constraintlayout.widget.ConstraintLayout;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Set;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

/* JADX INFO: loaded from: classes.dex */
public class KeyFrames {
    static HashMap sKeyMakers;
    private HashMap mFramesMap = new HashMap();

    static {
        HashMap map = new HashMap();
        sKeyMakers = map;
        try {
            map.put("KeyAttribute", KeyAttributes.class.getConstructor(null));
            sKeyMakers.put("KeyPosition", KeyPosition.class.getConstructor(null));
            sKeyMakers.put("KeyCycle", KeyCycle.class.getConstructor(null));
            sKeyMakers.put("KeyTimeCycle", KeyTimeCycle.class.getConstructor(null));
            sKeyMakers.put("KeyTrigger", KeyTrigger.class.getConstructor(null));
        } catch (NoSuchMethodException e) {
            Log.e("KeyFrames", "unable to load", e);
        }
    }

    public void addKey(Key key) {
        if (!this.mFramesMap.containsKey(Integer.valueOf(key.mTargetId))) {
            this.mFramesMap.put(Integer.valueOf(key.mTargetId), new ArrayList());
        }
        ArrayList arrayList = (ArrayList) this.mFramesMap.get(Integer.valueOf(key.mTargetId));
        if (arrayList != null) {
            arrayList.add(key);
        }
    }

    public KeyFrames() {
    }

    /* JADX WARN: Code duplicated, block: B:37:0x0079  */
    /* JADX WARN: Failed to restore switch over string. Please report as a decompilation issue */
    public KeyFrames(Context context, XmlPullParser xmlPullParser) {
        HashMap map;
        HashMap map2;
        byte b;
        Key keyAttributes;
        try {
            int eventType = xmlPullParser.getEventType();
            Key key = null;
            while (eventType != 1) {
                if (eventType == 2) {
                    String name = xmlPullParser.getName();
                    if (sKeyMakers.containsKey(name)) {
                        switch (name.hashCode()) {
                            case -300573030:
                                if (!name.equals("KeyTimeCycle")) {
                                    b = -1;
                                } else {
                                    b = 3;
                                }
                                break;
                            case -298435811:
                                if (!name.equals("KeyAttribute")) {
                                    b = -1;
                                } else {
                                    b = 0;
                                }
                                break;
                            case 540053991:
                                if (!name.equals("KeyCycle")) {
                                    b = -1;
                                } else {
                                    b = 2;
                                }
                                break;
                            case 1153397896:
                                if (!name.equals("KeyPosition")) {
                                    b = -1;
                                } else {
                                    b = 1;
                                }
                                break;
                            case 1308496505:
                                if (!name.equals("KeyTrigger")) {
                                    b = -1;
                                } else {
                                    b = 4;
                                }
                                break;
                            default:
                                b = -1;
                                break;
                        }
                        if (b == 0) {
                            keyAttributes = new KeyAttributes();
                        } else if (b == 1) {
                            keyAttributes = new KeyPosition();
                        } else if (b == 2) {
                            keyAttributes = new KeyCycle();
                        } else if (b == 3) {
                            keyAttributes = new KeyTimeCycle();
                        } else if (b == 4) {
                            keyAttributes = new KeyTrigger();
                        } else {
                            throw new NullPointerException("Key " + name + " not found");
                        }
                        keyAttributes.load(context, Xml.asAttributeSet(xmlPullParser));
                        addKey(keyAttributes);
                        key = keyAttributes;
                    } else if (name.equalsIgnoreCase("CustomAttribute")) {
                        if (key != null && (map2 = key.mCustomConstraints) != null) {
                            ConstraintAttribute.parse(context, xmlPullParser, map2);
                        }
                    } else if (name.equalsIgnoreCase("CustomMethod") && key != null && (map = key.mCustomConstraints) != null) {
                        ConstraintAttribute.parse(context, xmlPullParser, map);
                    }
                } else if (eventType == 3 && "KeyFrameSet".equals(xmlPullParser.getName())) {
                    return;
                }
                eventType = xmlPullParser.next();
            }
        } catch (IOException e) {
            Log.e("KeyFrames", "Error parsing XML resource", e);
        } catch (XmlPullParserException e2) {
            Log.e("KeyFrames", "Error parsing XML resource", e2);
        }
    }

    public void addAllFrames(MotionController motionController) {
        ArrayList arrayList = (ArrayList) this.mFramesMap.get(-1);
        if (arrayList != null) {
            motionController.addKeys(arrayList);
        }
    }

    public void addFrames(MotionController motionController) {
        ArrayList arrayList = (ArrayList) this.mFramesMap.get(Integer.valueOf(motionController.mId));
        if (arrayList != null) {
            motionController.addKeys(arrayList);
        }
        ArrayList arrayList2 = (ArrayList) this.mFramesMap.get(-1);
        if (arrayList2 != null) {
            int size = arrayList2.size();
            int i = 0;
            while (i < size) {
                Object obj = arrayList2.get(i);
                i++;
                Key key = (Key) obj;
                if (key.matches(((ConstraintLayout.LayoutParams) motionController.mView.getLayoutParams()).constraintTag)) {
                    motionController.addKey(key);
                }
            }
        }
    }

    public Set<Integer> getKeys() {
        return this.mFramesMap.keySet();
    }

    public ArrayList<Key> getKeyFramesForView(int i) {
        return (ArrayList) this.mFramesMap.get(Integer.valueOf(i));
    }
}
